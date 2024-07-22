using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    private GameObject player; 
    private GameObject breakerBox; 

    public bool destroyAfterUse; 

   
    private void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        breakerBox = GameObject.Find("BreakerBox"); 
    }

    
    public void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger zone is the player
        if (other.gameObject.tag == "Player")
        {
            // Check if the GameObject should be destroyed after use
            if (destroyAfterUse)
            {
                // If set to destroy after use, turn off the lights and then destroy this GameObject
                breakerBox.GetComponent<BreakerLightsOn>().powerIsOn = false; // Turn off the power in BreakerLightsOn script
                Destroy(gameObject); // Destroy this GameObject
            }

            // If not set to destroy after use, just turn off the lights without destroying this GameObject
            if (!destroyAfterUse)
            {
                breakerBox.GetComponent<BreakerLightsOn>().powerIsOn = false; // Turn off the power in BreakerLightsOn script
            }
        }
    }
}

