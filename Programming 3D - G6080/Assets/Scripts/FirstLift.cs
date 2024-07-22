using Unity.VisualScripting;
using UnityEngine;

public class FirstLift : MonoBehaviour
{
    public Animator lift;
    public GameObject openText;
    public bool grab;
    public NumPad NumPadScript;
    public AudioSource liftaudio;
    public Rigidbody liftRigidbody;  // Add this line

    private void Start()
    {
        grab = false;
        liftRigidbody = GetComponent<Rigidbody>();  // Add this line
        if (liftRigidbody != null)
            liftRigidbody.isKinematic = true;  // Make the Rigidbody kinematic initially
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
        if (grab && Input.GetButtonDown("Interact") && NumPadScript.useLift == true)
        {
            UseLift();
            liftaudio.Play();
        }
    }

    void UseLift()
    {
        //Debug.Log("Closes");
        lift.SetBool("Down", true);

        if (liftRigidbody != null)
            liftRigidbody.isKinematic = false;  // Enable Rigidbody physics when the lift is activated
    }
}

