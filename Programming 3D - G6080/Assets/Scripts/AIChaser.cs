using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    // Reference to the NavMeshAgent component for AI movement
    public NavMeshAgent ai;

    // Reference to the player's transform
    public Transform player;

    // Destination for the AI to follow (player's position)
    Vector3 dest;

    // Reference to the player's camera
    public Camera playerCam;

    // Speed of the AI
    public float aiSpeed;

    public AudioSource walking;

    void Update()
    {
        // Calculate frustum planes of the player's camera
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCam);

        // Calculate the distance between the AI and the player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Check if the AI is within the player's camera view
        if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
        {
            // If the AI is in view, stop its movement and pause audio
            ai.speed = 0;
            walking.Pause();
        }

        // Check if the AI is outside the player's camera view
        if (!GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds))
        {
            // If the AI is outside view, set its speed and destination to the player
            ai.speed = aiSpeed;
            dest = player.position;
            ai.destination = dest;

            // Check if audio is not playing, then play it
            if (!walking.isPlaying)
            {
                walking.Play();
            }
        }
    }
}


