using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Reference to the player GameObject
    public GameObject player;

    // Attack range variables
    private float attackRange;
    public float minDamage;
    public float maxDamage;

    // Damage variables
    public float damageSet = 25f;
    public bool randomDamage;
    public bool setDamage;

    // Audio variables
    public AudioClip[] sounds;
    public AudioSource source;

    private void Start()
    {
        // Initialize attack range within the specified damage range
        attackRange = Random.Range(minDamage, maxDamage);

        // Check if the player GameObject is assigned
        if (player != null)
        {
            // Get AudioSource component from the player GameObject
            source = player.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned to the EnemyDamage script!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player GameObject is assigned
        if (player != null)
        {
            // Check if the colliding object is the player and randomDamage is enabled
            if (other.gameObject.tag == "Player" && randomDamage)
            {
                // Get the PlayerHealth component from the player GameObject
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

                // Inflict random damage to the player and play a random sound
                if (playerHealth != null)
                {
                    playerHealth.health -= attackRange;
                    source.clip = sounds[Random.Range(0, sounds.Length)];
                    source.Play();
                }
                else
                {
                    Debug.LogError("PlayerHealth component not found on the player GameObject!");
                }
            }

            // Check if the colliding object is the player and setDamage is enabled
            if (other.gameObject.tag == "Player" && setDamage)
            {
                // Get the PlayerHealth component from the player GameObject
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

                // Inflict set damage to the player and play a random sound
                if (playerHealth != null)
                {
                    playerHealth.health -= damageSet;
                    source.clip = sounds[Random.Range(0, sounds.Length)];
                    source.Play();
                }
                else
                {
                    Debug.LogError("PlayerHealth component not found on the player GameObject!");
                }
            }
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned to the EnemyDamage script!");
        }
    }
}

