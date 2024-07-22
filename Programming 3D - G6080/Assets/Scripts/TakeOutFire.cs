using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeOutFire : MonoBehaviour
{
    public CollectWater CollectWaterScript;
    public BucketPickUp BucketPickUpScript;
    public GameObject Fire;
    public GameObject Key;
    public GameObject FireText;
    public GameObject Buckethud;

    public AudioSource TakeoutFire;


    public bool grab;
    public bool noText = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab" && noText == false)
        {
            grab |= true;
            FireText.SetActive(true);
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = false;
            FireText.SetActive(false);
        }
    }
    private void Update()
    {
        

        if (Input.GetButtonDown("Interact") && grab && CollectWaterScript.bucketWithWater == true)
        {
            Debug.Log("Trying to deactivate Fire."); // Add this line for debugging

            Fire.SetActive(false);
            Key.SetActive(true);
            noText = true;
            
            CollectWaterScript.bucketWithWater = false;
            Buckethud.SetActive(false);
            TakeoutFire.Play();

        }

       
    }
}
