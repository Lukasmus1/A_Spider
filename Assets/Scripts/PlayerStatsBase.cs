using System;

[Serializable]
public abstract class PlayerStatsBase
{
    public abstract int PriceToUpgrade { get; set; }
    public abstract float PriceMultiplier { get; }
    protected virtual int BuyCountMultiplier { get; set; } = 10;
    public abstract float Value { get; set; }
    public abstract float ValueMultiplier { get; set; }

    public virtual int Upgrade()
    {
        Value += ValueMultiplier * BuyCountMultiplier;
        
        PriceToUpgrade = (int)(PriceToUpgrade + BuyCountMultiplier * PriceMultiplier);
        BuyCountMultiplier += 10;
        return 0;
    }
}