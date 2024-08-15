using System;

[Serializable]
public class CooldownScript : PlayerStatsBase
{
    //Derived from PlayerStatsBase
    private float _value = 1.5f;
    public override float Value
    {
        get => _value;
        set
        {
            if (_value <= 0)
            {
                _value = 0;
            }
            else
            {
                _value = value;
            }
        }
    }
    public override float ValueMultiplier { get; set; } = 0.001f;
    public override int PriceToUpgrade { get; set; } = 150;
    public override float PriceMultiplier { get; } = 1.4f;
    protected override int BuyCountMultiplier { get; set; } = 5;

    public override void Upgrade()
    {
        Value -= ValueMultiplier * BuyCountMultiplier;
        
        PriceToUpgrade = (int)(PriceToUpgrade + BuyCountMultiplier * PriceMultiplier);
        BuyCountMultiplier += 10;
    }
}
