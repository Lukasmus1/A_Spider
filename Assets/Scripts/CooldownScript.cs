using System;

[Serializable]
public class CooldownScript : IPlayerStats
{
    public float ShotCooldown { get; set; } = 1.5f;
    public int PriceToUpgrade { get; set; } = 150;
    public float PriceMultiplier { get; } = 1.4f;
}
