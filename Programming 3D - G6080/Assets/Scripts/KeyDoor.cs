using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public KeyCollect KeyCollectScript; 
    public Animator door; 
    public GameObject openText; 

    public AudioSource doorSound; 

    public bool grab; 

    private void Start()
    {
        grab = false; // Initialize grab as false
    }

    // Triggered when a GameObject with a Collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab") // Check if the colliding object is tagged as "Grab"
        {
            grab = true; // Set grab to true indicating that the door can be interacted with
            openText.SetActive(true); // Show the open text
        }
    }

    // Triggered when a GameObject with a Collider exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab") // Check if the colliding object is tagged as "Grab"
        {
            grab = false; // Set grab to false indicating that the door can no longer be interacted with
            openText.SetActive(false); // Hide the open text
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the player is in grab range, the interact button is pressed, and the player has the key
        if (grab && Input.GetButtonDown("Interact") && KeyCollectScript.hasKey == true)
        {
            OpenDoor(); // Call the OpenDoor method to open the door
        }
        else
        {
            CloseDoor(); // Close the door if the conditions are not met
        }
    }

    // Method to handle the opening of the door
    void OpenDoor()
    {
        // Set the Animator parameters to open the door
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play(); // Play the door opening sound
    }

    // Method to handle the closing of the door
    void CloseDoor()
    {
        // Set the Animator parameters to close the door
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
    }
}

