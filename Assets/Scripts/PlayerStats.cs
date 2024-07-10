using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public int Points { get; set; } = 0;

    public int Health { get; set; } = 100;
    
    public int Damage { get; set; } = 10;

    public float InvincibilityTime { get; } = 0.5f;

    public bool IsInvincible { get; set; }

    private float _invincibilityTimer;


    private void Update()
    {
        if (!IsInvincible) 
            return;
        
        _invincibilityTimer += Time.deltaTime;
        if (_invincibilityTimer >= InvincibilityTime)
        {
            IsInvincible = false;
            _invincibilityTimer = 0;
        }
    }
}
