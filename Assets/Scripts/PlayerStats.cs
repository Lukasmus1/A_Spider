using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

#if UNITY_EDITOR
    [SerializeField] private bool infiniteHealth;
#endif
    
    public delegate void Death();
    public event Death OnDeath;

    public int Points { get; set; }

    private int _health;
    public int Health
    {
        get => _health;

        set
        {
#if UNITY_EDITOR
            if (infiniteHealth)
            {
                return;
            }
#endif
            
            _health = value;
            if (_health <= 0)
            {
                _health = 0;
                OnDeath?.Invoke();
            }
        }

    }
    public int MaxHealth { get; set; }
    
    public int Damage { get; set; }

    public float InvincibilityTime { get; set; }

    public bool IsInvincible { get; set; }
    private float _invincibilityTimer;
    
    public float ShotCooldown { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        
        SavingSystem.LoadPlayerStats().LoadVarsToPlayer(Instance);
        Health = MaxHealth;
    }

    private void OnDisable()
    {
        OnDeath = null;
    }
    
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
