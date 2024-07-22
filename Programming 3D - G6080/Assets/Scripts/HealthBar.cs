using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerHealth player;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        CurrentHealth = player.health;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
