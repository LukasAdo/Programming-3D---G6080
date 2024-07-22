
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioSource turnOnSound;
    public AudioSource turnOffSound;

    private bool isCollected = false;
    private bool isOn = false;

    void Start()
    {
        flashlight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isCollected)
        {
            Debug.Log("Fire1 button pressed");
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        isOn = !isOn;
        flashlight.SetActive(isOn);
        if (isOn && Input.GetButtonDown("Fire1"))
        {
            turnOnSound.Play();
        }
        else if (!isOn && Input.GetButtonDown("Fire1"))
        {
            turnOffSound.Play();
        }
    }

    // Call this method when the flashlight is collected
    public void CollectFlashlight()
    {
        Debug.Log("CollectFlashlight method called");
        isCollected = true;
        flashlight.SetActive(false);
    }
}

