using System;

[Serializable]
public class HealthClass : IPlayerStats
{
    private bool _infiniteHealth;
    
    private int _health;
    public int Health
    {
        get => _health;

        set
        {
#if UNITY_EDITOR
            if (_infiniteHealth)
            {
                return;
            }
#endif
            
            _health = value;
            if (_health <= 0)
            {
                _health = 0;
                PlayerStats.Instance.InvokeOnDeath();
            }
        }

    }

    public int MaxHealth { get; set; } = 100;
    
    public int PriceToUpgrade { get; set; } = 50;
    public float PriceMultiplier { get; } = 1.5f;

    public void SetVars(ref bool infiniteHealth)
    {
        _infiniteHealth = infiniteHealth;
        Health = MaxHealth;
    }
}
