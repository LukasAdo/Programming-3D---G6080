using System.Collections;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;

    // Interaction range with the ladder
    public float range = 0.5f;

    // Flag indicating if the player is touching the ladder
    public bool Touching = false;

    // Climb speed
    public float UpSpeed = 1f;

    // Target climb height for the player
    public float targetClimbHeight = 2.0f;

    // Camera associated with the ladder
    public Camera LadderCam;

    public AudioSource sound;

    private void Update()
    {
        // Check for interaction with the ladder
        Shoot();

        // If 'w' key is pressed and the player is touching the ladder, start climbing
        if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) && Touching == true)
        {
            StartCoroutine(StartClimb());
            sound.enabled = true;
            sound.loop = true;
            sound.Play(); // Add this line to start playing the audio
        }
        else if( Touching == false)
        {
            sound.enabled = false;
            sound.loop = false;
        }
        

    }

    // Raycast to detect if the player is touching the ladder
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(LadderCam.transform.position, LadderCam.transform.forward, out hit, range))
        {
            // Check if the object hit is a target (assumed to be on the ladder)
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Touching = true;
            }
            else
            {
                Touching = false;
            }
        }
        else
        {
            Touching = false;
        }
    }

    // Coroutine for climbing the ladder
    IEnumerator StartClimb()
    {
        Debug.Log("Climbing started");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        float initialHeight = transform.position.y;
        float climbDistance = 0f;

        // Continue climbing until reaching the target climb height
        while (climbDistance < targetClimbHeight)
        {
            float climbStep = UpSpeed * Time.fixedDeltaTime;
            Vector3 newPosition = transform.position + Vector3.up * climbStep;
            rb.MovePosition(newPosition);
            climbDistance = transform.position.y - initialHeight;

            yield return new WaitForFixedUpdate();
        }

        // Set the character's vertical velocity to zero when climbing is complete
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Notify the target that climbing is complete
        Target target = GetComponentInChildren<Target>();
        if (target != null)
        {
            target.ClimbingComplete(climbDistance);
        }

        // Reset flags and properties
        Touching = false;
        rb.isKinematic = false;

        
       

        Debug.Log("Climbing finished at a distance of " + climbDistance + " units");
    }
}


