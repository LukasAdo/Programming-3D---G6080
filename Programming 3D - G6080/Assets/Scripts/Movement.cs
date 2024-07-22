using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Flashlight flashlightScript;

    // Movement parameters
    public float moveSpeed;
    public float groundDrag;
    public float playerHeight;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask WhatIsGround;
    bool grounded;

    // Player orientation and input variables
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    Rigidbody rb;

    // Jumping parameters
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;
    public KeyCode jumpKey = KeyCode.Space;

    // Animator and animation controllers
    public Animator animator;
    public RuntimeAnimatorController idleController;
    public RuntimeAnimatorController walkController;
    public RuntimeAnimatorController jumpController;

    void Start()
    {
        ResetJump();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = false;

        flashlightScript = GetComponentInChildren<Flashlight>();
    }

    private void Update()
    {
        // Check if the player is grounded
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, WhatIsGround);

        // Debug statements
        if (grounded)
        {
            Debug.Log("Player is grounded");
        }
        else
        {
            Debug.Log("Player is not grounded");
        }

        // Check for jump input and perform the jump if conditions are met
        if (Input.GetKeyDown(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // Process other input
        MyInput();
    }

    private void FixedUpdate()
    {
        // Move the player and control speed
        MovePlayer();
        SpeedControl();

        // Apply drag when grounded
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void MyInput()
    {
        // Get horizontal and vertical input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Check for movement input and switch animation controllers accordingly
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            SwitchAnimatorController(walkController);
        }
        else if (grounded)
        {
            SwitchAnimatorController(idleController);
        }

        
    }

    private void MovePlayer()
    {
        // Get the forward direction of the character, ignoring the y-axis
        Vector3 characterForward = Vector3.Scale(orientation.forward, new Vector3(1, 0, 1)).normalized;

        // Calculate the movement direction based on input and character orientation
        moveDirection = characterForward * verticalInput + orientation.right * horizontalInput;

        // Apply force to the rigidbody based on whether the player is grounded or not
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        // Limit the player's speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // Perform the jump
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        // Switch to jump controller when jumping
        SwitchAnimatorController(jumpController);
    }

    void OnTriggerEnter(Collider other)
    {
        // Handle trigger events, e.g., picking up a flashlight
        if (other.CompareTag("Player"))
        {
            Flashlight flashlightScript = other.GetComponent<Flashlight>();
            if (flashlightScript != null)
            {
                flashlightScript.CollectFlashlight();
                Destroy(gameObject); // Destroy or deactivate the pickup object
                Debug.Log("Flashlight picked up");
            }
            else
            {
                Debug.LogWarning("Flashlight script not found on the player.");
            }
        }
        else
        {
            Debug.LogWarning("Triggered by an object with tag: " + other.tag);
        }
    }

    private void ResetJump()
    {
        // Reset the jump state
        readyToJump = true;
    }

    void SwitchAnimatorController(RuntimeAnimatorController newController)
    {
        // Set the new Animator Controller
        animator.runtimeAnimatorController = newController;
    }
}


