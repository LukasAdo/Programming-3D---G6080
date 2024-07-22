using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketPickUp : MonoBehaviour
{
    public GameObject Bucket;
    public bool hasBucket;
    public GameObject Buckethud;

    public AudioSource PickupBucket;
    // Start is called before the first frame update
    private void Start()
    {
        hasBucket = false;
        Bucket.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Player has collected the map, set the HUD object active
            Bucket.SetActive(false);
            Buckethud.SetActive(true);
            hasBucket = true;
            PickupBucket.Play();
            // You might want to play a sound, update a UI, or perform other actions here

            // Disable the collider so that the map can't be collected again
            GetComponent<Collider>().enabled = false;


            gameObject.SetActive(false);
        }
    }
}
