using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    


    public GameObject pickupText;
    public AudioSource pickupSound;

    public bool grab;
    void Start()
    {
        noteUI.SetActive(false);
        pickupText.SetActive(false);

        grab = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = true;
            pickupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = false;
            pickupText.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && grab)
        {
            // Open the note when the 'Interact' button is pressed
            noteUI.SetActive(true);
           

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void ExitButton()
    {
        Debug.Log("ExitButton clicked");
        noteUI.SetActive(false);
    }
}