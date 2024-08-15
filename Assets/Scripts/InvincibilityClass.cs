using System;

[Serializable]
public class InvincibilityClass : PlayerStatsBase
{
    //Derived from PlayerStatsBase
    public override float Value { get; set; } = 0.5f;
    public override float ValueMultiplier { get; set; } = 0.001f;
    public override int PriceToUpgrade { get; set; } = 500;
    public override float PriceMultiplier { get; } = 2;
    
    //Property to help with the invincibility in PlayerStats
    public bool IsInvincible { get; set; }
}
