using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    public delegate void Death();
    public event Death OnDeath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void OnDisable()
    {
        OnDeath = null;
    }

    public int Points { get; set; } = 0;

    private int _health = 100;
    public int Health
    {
        get => _health;

        set
        {
            _health = value;
            if (_health <= 0)
            {
                _health = 0;
                OnDeath?.Invoke();
            }
        }

    }

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
