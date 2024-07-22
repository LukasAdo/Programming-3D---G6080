using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerLogic : MonoBehaviour
{
    public CinemachineFreeLook freelookCamera; // Reference to your FreeLook camera.
    private float originalFOV; // Store the original FOV value.

    private void Start()
    {
        // Store the original FOV when the script starts.
        originalFOV = freelookCamera.m_Lens.FieldOfView;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Change the FOV for the inside view.
            freelookCamera.m_Lens.FieldOfView = 30f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the FOV to its original value when the player exits the trigger zone.
            freelookCamera.m_Lens.FieldOfView = originalFOV;
        }
    }
}
