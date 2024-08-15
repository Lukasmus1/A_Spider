using System;

[Serializable]
public class DamageClass : IPlayerStats
{
    public int Damage { get; set; } = 10;
    public int PriceToUpgrade { get; set; } = 100;
    public float PriceMultiplier { get; } = 1.5f;
}
