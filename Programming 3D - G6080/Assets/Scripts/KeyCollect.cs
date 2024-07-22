using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public GameObject Key;
    public bool hasKey;
    public GameObject keyHud;
    public GameObject KeyText;
    
    public bool grab;


    public AudioSource key;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab |= true;
            KeyText.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            grab = false;
            KeyText.SetActive(false);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        hasKey = false;
        
    }

    private void Update()
    {
         if (Input.GetButtonDown("Interact") && grab)
        {


            Key.SetActive(false);
            hasKey = true;
            keyHud.SetActive(true);
            KeyText.SetActive(false);
            
            key.Play();
        }
    }
 }
