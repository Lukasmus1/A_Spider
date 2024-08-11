using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

#if UNITY_EDITOR
    [SerializeField] private bool infiniteHealth;
#endif
    
    public delegate void Death();
    public event Death OnDeath;
    
    public HealthClass HealthInstance { get; set; }
    public DamageClass DamageInstance { get; set; }
    public InvincibilityClass InvincibilityInstance { get; set; }
    public PointsClass PointsInstance { get; set; }
    public CooldownScript CooldownInstance { get; set; }
    
    private float _invincibilityTimer;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        
        SavingSystem.LoadPlayerStats().LoadVarsToPlayer(Instance);
        HealthInstance.SetVars(ref infiniteHealth);
    }

    private void OnDisable()
    {
        OnDeath = null;
    }
    
    private void Update()
    {
        if (!InvincibilityInstance.IsInvincible) 
            return;
        
        _invincibilityTimer += Time.deltaTime;
        if (_invincibilityTimer >= InvincibilityInstance.InvincibilityTime)
        {
            InvincibilityInstance.IsInvincible = false;
            _invincibilityTimer = 0;
        }
    }
    
    public void InvokeOnDeath()
    {
        OnDeath?.Invoke();
    }
}
