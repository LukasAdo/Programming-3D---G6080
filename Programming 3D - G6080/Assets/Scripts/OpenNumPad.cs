using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNumPad : MonoBehaviour
{
    // Reference to the GameObject representing the numpad
    public GameObject numPadObject;

    // Reference to the GameObject representing the text associated with the numpad
    public GameObject numPadText;

    // Flag indicating if the player can grab the numpad
    public bool grab;

    private void Start()
    {
        // Initialize the grab flag to false
        grab = false;
    }

    // Called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the "Grab" tag
        if (other.gameObject.tag == "Grab")
        {
            // Set the grab flag to true and activate the numpad text
            grab |= true;
            numPadText.SetActive(true);
        }
    }

    // Called when another collider exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider has the "Grab" tag
        if (other.gameObject.tag == "Grab")
        {
            // Set the grab flag to false and deactivate the numpad text
            grab = false;
            numPadText.SetActive(false);
        }
    }

    
    private void Update()
    {
        // Check if the interact button is pressed and the grab flag is true
        if (Input.GetButtonDown("Interact") && grab)
        {
            // Activate the numpad object and deactivate the numpad text
            numPadObject.SetActive(true);
            numPadText.SetActive(false);
        }
    }
}

