using System;

[Serializable]
public class HealthClass : PlayerStatsBase
{
    //Derived from PlayerStatsBase
    public override float Value { get; set; } = 100;
    public override float ValueMultiplier { get; set; } = 2;

    public override int PriceToUpgrade { get; set; } = 50;
    public override float PriceMultiplier { get; } = 1.5f;
    
    //Debug UnityEditor only property
    private bool _infiniteHealth;
    
    //Health property
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

    public void SetVars(ref bool infiniteHealth)
    {
        _infiniteHealth = infiniteHealth;
        Health = (int)Value;
    }
}
