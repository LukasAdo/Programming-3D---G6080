using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start method is called.");

        // Your initialization code goes here

        Debug.Log("Initialization completed.");

        // Check if there are any pause conditions here

        Debug.Log("Checking for pause conditions.");

        // Continue with the rest of your code

        Debug.Log("Game is running.");

        // ...
    }
    public static GameManager Instance; // Singleton instance.

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one GameManager exists.
        }
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        // Update the UI to display the new score, if needed.
    }

    // You can add other game management functions here.
}
