using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnemy : MonoBehaviour
{
    public GameObject enemyRemove;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
           
           


         enemyRemove.SetActive(false);
        }
    }
}
