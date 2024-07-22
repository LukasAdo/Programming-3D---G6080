using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour
{
    public GameObject player;
    public GameObject Numpad; // Reference to the Numpad UI object in the scene

    public GameObject text; 

    public GameObject animateObject;
    public Animator animator; 

    public Text textObject; 
    public string answer = "12345"; 

    public AudioSource button; 
    public AudioSource correct; 
    public AudioSource wrong; 

    public bool animate; 
    bool answerRight = false; 
    public bool useLift = false; 

    private void Start()
    {
        Numpad.SetActive(false); // Initially hide the Numpad UI
    }

    // Called when a number button on the numpad is pressed
    public void Number(int number)
    {
        textObject.text += number.ToString(); // Append the pressed number to the display text
        button.Play(); // Play the button press sound
    }

    // Called when the execute/enter button on the numpad is pressed
    public void Execute()
    {
        Debug.Log("Execute method called");

        if (textObject.text.Trim() == "12345") // Check if the entered code is correct
        {
            correct.Play(); // Play correct sound
            textObject.text = "Right"; // Update display text
            Debug.Log("Answer is correct!");
        }
        else
        {
            wrong.Play(); // Play wrong sound
            textObject.text = "Wrong"; // Update display text
            Debug.Log("Answer is incorrect.");
        }
    }

    // Called to clear the current input on the numpad
    public void Clear()
    {
        textObject.text = " "; // Clear the display text
        button.Play(); // Play button press sound
    }

    // Called to exit/close the numpad UI
    public void Exit()
    {
        Numpad.SetActive(false); // Hide the Numpad UI
    }
    public void Update()
    {
        Debug.Log("Update method called");  // Debug statement to check if the Update method is being called

        if (textObject.text == "Right") //&& animate
        {
           
            useLift = true;
            Debug.Log("OPEN DOOR");
        }

        if (Numpad.activeInHierarchy)
        {
            
            text.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Numpad is active - Cursor visible: " + Cursor.visible + ", Cursor lock state: " + Cursor.lockState);
        }
        else
        {
           
            text.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Numpad is not active - Cursor visible: " + Cursor.visible + ", Cursor lock state: " + Cursor.lockState);
        }
    }
}
