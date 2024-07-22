using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject flashlight;
    public Flashlight flashlightScript;
    public GameObject hudLightObject;

    public GameObject beforeMannequin;
    public GameObject afterMannequin;

    public AudioSource equip;
    public AudioSource atmosphere;
    public AudioSource demonicChant;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone");

            // Log all components attached to the player GameObject
            Component[] components = other.GetComponents<Component>();
            Debug.Log("Components on player GameObject:");
            foreach (var component in components)
            {
                Debug.Log(component.GetType().Name);
            }

            flashlightScript = other.GetComponent<Flashlight>();
            if (flashlightScript != null)
            {
                Debug.Log("Flashlight script found on the player GameObject");

                flashlightScript.CollectFlashlight();

                // Deactivate or disable the pickup object instead of destroying it
                beforeMannequin.SetActive(false);
                afterMannequin.SetActive(true);
                gameObject.SetActive(false);
                hudLightObject.SetActive(true);
                equip.Play();

                // Use Invoke to delay the execution of demonicChant and atmosphere
                float delay = equip.clip.length; // Use the length of the equip audio clip as the delay
                PlayDemonicChantAndAtmosphere();

                Debug.Log("Flashlight picked up");
            }
            else
            {
                Debug.LogWarning("Flashlight script not found on the player GameObject.");
            }
        }

        void PlayDemonicChantAndAtmosphere()
        {
            demonicChant.Play();
            atmosphere.Play();
        }
    }
}

