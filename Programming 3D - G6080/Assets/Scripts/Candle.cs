using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public LighterPickUp lighterPickUpScript; // Reference to the LighterPickUp script
    public GameObject fireLit;
    public GameObject fireSpotLight;
    public GameObject candleText;

    public bool grab;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab |= true;
            candleText.SetActive(true);
        }

      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = false;
            candleText.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && grab && lighterPickUpScript.hasLighter == true)
        {
            fireLit.SetActive(true);
            fireSpotLight.SetActive(true);
            

        }
    }
}

