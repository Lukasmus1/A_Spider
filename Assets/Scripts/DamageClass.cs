using System;

[Serializable]
public class DamageClass : PlayerStatsBase
{
    public override float Value { get; set; } = 10;
    public override float ValueMultiplier { get; set; } = 0.5f;
    public override int PriceToUpgrade { get; set; } = 100;
    public override float PriceMultiplier { get; } = 1.5f;
}
