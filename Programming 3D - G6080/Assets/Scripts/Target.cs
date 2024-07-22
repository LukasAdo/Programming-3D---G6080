using UnityEngine;

public class Target : MonoBehaviour
{
    // Initial climb required for completion
    public float climb = 2f;

    // Method called when climbing is complete
    public void ClimbingComplete(float climbedDistance)
    {
        // Subtract the climbed distance from the total climb required
        climb -= climbedDistance;

        // Check if the climb requirement is met
        if (climb <= 0)
        {
            // If climb requirement is met, call the Go() method
            Go();
        }
    }

    // Method to be called when climb requirement is met
    void Go()
    {
        // Destroy the target GameObject
        Destroy(gameObject);
    }
}


