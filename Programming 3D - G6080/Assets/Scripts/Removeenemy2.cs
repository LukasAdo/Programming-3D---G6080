using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removeenemy2 : MonoBehaviour
{
    public GameObject enemyRemove;
    public GameObject enemyRemove2;
    public GameObject enemyRemove3;
    public GameObject enemyRemove4;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {




            enemyRemove.SetActive(false);
            enemyRemove2.SetActive(false);
            enemyRemove3.SetActive(false);
            enemyRemove4.SetActive(false);
        }
    }
}
