using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public GameObject player;
    private float attackRange;
    public float damageSet = 25f;
    public bool setDamage;

    public AudioClip[] sounds;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && setDamage)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.health -= damageSet;
                source.clip = sounds[Random.Range(0, sounds.Length)];
                source.Play();
            }
            
        }

    }
}
