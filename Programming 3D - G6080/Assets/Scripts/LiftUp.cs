using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUp : MonoBehaviour
{
    public Animator lift;
    public GameObject openText;
    public bool grab;
    public NumPad NumPadScript;

 

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

    private void FixedUpdate()
    {
        if (grab && Input.GetButtonDown("Interact") && NumPadScript.useLift)
        {
            UseLift();
        }
    }

    void UseLift()
    {
        lift.SetBool("Up", true);
    }
}

