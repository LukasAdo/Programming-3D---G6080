using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerLightsOn : MonoBehaviour
{
    public GameObject[] lights; 
    public GameObject text; 
    public bool powerIsOn; 
    private bool grab; 

    public AudioSource mapCollection; // Audio source for playing sound when power is turned on

    // Start is called before the first frame update
    private void Start()
    {
        // Initially turn off all lights
        foreach (GameObject ob in lights)
        {
            ob.SetActive(false);
        }

        // Hide the interaction text initially
        text.SetActive(false);
    }

    // Triggered when a GameObject with a Collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player and the power is off
        if (other.gameObject.tag == "Grab" && !powerIsOn)
        {
            grab = true; // Set grab to true, allowing interaction
            text.SetActive(true); // Show interaction text
        }
    }

    // Triggered when a GameObject with a Collider exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger is the player and the power is off
        if (other.gameObject.tag == "Grab" && !powerIsOn)
        {
            grab = false; // Set grab to false, preventing interaction
            text.SetActive(false); // Hide interaction text
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the interact button is pressed and the player is in grab range
        if (Input.GetButtonDown("Interact") && grab)
        {
            powerIsOn = true; // Turn the power on
            mapCollection.Play(); // Play the sound effect
        }

        // If power is on, activate all lights
        if (powerIsOn)
        {
            foreach (GameObject ob in lights)
            {
                ob.SetActive(true); // Turn on each light
            }

            grab = false; // Set grab to false as the breaker has been activated
            text.SetActive(false); // Hide interaction text
        }

        // If power is off, deactivate all lights
        if (!powerIsOn)
        {
            foreach (GameObject ob in lights)
            {
                ob.SetActive(false); // Turn off each light
            }
        }
    }
}


