using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWater : MonoBehaviour
{
    public BucketPickUp BucketPickUpScript;
    public GameObject Buckethud;
    public GameObject BucketText;

    public bool grab;
    public bool bucketWithWater;

    public AudioSource waterCollection;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab |= true;
            BucketText.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = false;
            BucketText.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Interact") && grab && BucketPickUpScript.hasBucket == true)
        {

            Buckethud.SetActive(true);
            bucketWithWater = true;
            waterCollection.Play();
        }
    }
}
