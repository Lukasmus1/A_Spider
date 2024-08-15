using System;

[Serializable]
public class InvincibilityClass : IPlayerStats
{
    public float InvincibilityTime { get; set; } = 0.5f;

    public bool IsInvincible { get; set; }
    public int PriceToUpgrade { get; set; } = 500;
    public float PriceMultiplier { get; } = 2;
}
