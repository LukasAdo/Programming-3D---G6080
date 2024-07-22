using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public AudioSource doorSound;

    public bool grab;

    private void Start()
    {
        grab = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = false;
            openText.SetActive(false);
        }
    }

    private void Update()
    {
        if (grab && Input.GetButtonDown("Interact"))
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        //Debug.Log("Opens");
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();
    }
    void CloseDoor()
    {
        //Debug.Log("Closes");
        door.SetBool("Open", false);
        door.SetBool("Closed", true);

    }
}
