using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterPickUp : MonoBehaviour
{
    public GameObject lighter;
    public bool hasLighter;
    public GameObject firehud;

    private void Start()
    {
        hasLighter = false;
        lighter.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Player has collected the map, set the HUD object active
            lighter.SetActive(false);
            firehud.SetActive(true);
            hasLighter = true;
            // You might want to play a sound, update a UI, or perform other actions here

            // Disable the collider so that the map can't be collected again
            GetComponent<Collider>().enabled = false;


            gameObject.SetActive(false);
        }
    }

    
}