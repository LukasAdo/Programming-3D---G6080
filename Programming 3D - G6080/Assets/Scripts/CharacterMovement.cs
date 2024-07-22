using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Flashlight flashlightScript;

    public float moveSpeed;

    public float groundDrag;
    public float playerHeight;
    public LayerMask WhatIsGround;
    bool grounded;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    public Transform orientation;

    public KeyCode jumpKey = KeyCode.Space;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public Rigidbody rb;

    public Animator animator;
    public RuntimeAnimatorController idleController;
    public RuntimeAnimatorController walkController;
    public RuntimeAnimatorController jumpController;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        flashlightScript = GetComponentInChildren<Flashlight>();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);
        MyInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else 
            rb.drag = 0;
    }
    private void FixedUpdate()
    {
        MovePlayer();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (horizontalInput != 0f || verticalInput != 0f)
        {
            // If there's movement input, switch to the walk controller
            SwitchAnimatorController(walkController);
        }
        else if (grounded)
        {
            // If no movement input and grounded, switch to the idle controller
            SwitchAnimatorController(idleController);
        }
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }
    
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        // Switch to jump controller when jumping
        SwitchAnimatorController(jumpController);

    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    void SwitchAnimatorController(RuntimeAnimatorController newController)
    {
        // Set the new Animator Controller
        animator.runtimeAnimatorController = newController;
    }

}
