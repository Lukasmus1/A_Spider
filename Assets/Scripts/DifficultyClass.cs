using System;

[Serializable]
public class DifficultyClass : PlayerStatsBase
{
    public override int PriceToUpgrade { get; set; } = 500;
    public override float PriceMultiplier { get; } = 2;
    public override float Value { get; set; } = 1;
    public override float ValueMultiplier { get; set; } = 0.1f;
}
