using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCollection : MonoBehaviour
{
    public GameObject hudObject;
    public GameObject mapObject;
    
    

    public AudioSource mapCollection;
    void Start()
    {

        hudObject.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Player has collected the map, set the HUD object active
            hudObject.SetActive(true);
            mapObject.SetActive(true);
            

            // You might want to play a sound, update a UI, or perform other actions here

            // Disable the collider so that the map can't be collected again
            GetComponent<Collider>().enabled = false;


            gameObject.SetActive(false);
        }
    }
}