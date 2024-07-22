using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject hud;
    public GameObject deathScreen;
    public GameObject player;

    public float health = 100f;
    public AudioSource slowHeartBeat;
    public AudioSource midHeartBeat;
    public AudioSource fastHeartBeat;

    private bool isSlowHeartBeatPlaying = false;
    private bool isMidHeartBeatPlaying = false;

    private void Start()
    {
        deathScreen.SetActive(false);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hud.SetActive(false);
            deathScreen.SetActive(true);
        }

        health = Mathf.Clamp(health, 0f, 100f);

        if (health > 70)
        {
            Debug.Log("Playing slow heartbeat");
            if (!isSlowHeartBeatPlaying)
            {
                slowHeartBeat.Play();
                isSlowHeartBeatPlaying = true;
            }

            if (isMidHeartBeatPlaying)
            {
                midHeartBeat.Stop();
                isMidHeartBeatPlaying = false;
            }

            if (fastHeartBeat.isPlaying)
            {
                fastHeartBeat.Stop();
            }
        }
        else if (health > 40)
        {
            if (isSlowHeartBeatPlaying)
            {
                slowHeartBeat.Stop();
                isSlowHeartBeatPlaying = false;
            }

            if (!isMidHeartBeatPlaying)
            {
                midHeartBeat.Play();
                isMidHeartBeatPlaying = true;
            }

            if (fastHeartBeat.isPlaying)
            {
                fastHeartBeat.Stop();
            }
        }
        else if (health > 0)
        {
            if (isSlowHeartBeatPlaying)
            {
                slowHeartBeat.Stop();
                isSlowHeartBeatPlaying = false;
            }

            if (isMidHeartBeatPlaying)
            {
                midHeartBeat.Stop();
                isMidHeartBeatPlaying = false;
            }

            if (!fastHeartBeat.isPlaying)
            {
                fastHeartBeat.Play();
            }
        }
    }
}

