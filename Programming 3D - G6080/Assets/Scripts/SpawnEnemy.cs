using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {




            spawn1.SetActive(true);
            spawn2.SetActive(true);
            spawn3.SetActive(true);
            spawn4.SetActive(true);
        }
    }
}
