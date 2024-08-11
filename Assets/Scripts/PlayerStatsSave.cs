using System;

//This class is here because Unity's serialization doesn't work on classes that derive from MonoBehaviour
[Serializable]
public class PlayerStatsSave
{
    public HealthClass HealthInst { get; set; } = new HealthClass();
    public PointsClass PointsInst { get; private set; } = new PointsClass();
    public DamageClass DamageInst { get; private set; } = new DamageClass();
    public InvincibilityClass InvincibilityInst { get; private set; } = new InvincibilityClass();
    public CooldownScript CooldownInst { get; private set; } = new CooldownScript();

    public void SetVars(PlayerStats playerStats)
    {
        HealthInst = playerStats.HealthInstance;
        PointsInst = playerStats.PointsInstance;
        DamageInst = playerStats.DamageInstance;
        InvincibilityInst = playerStats.InvincibilityInstance;
        CooldownInst = playerStats.CooldownInstance;
    }
    
    public void LoadVarsToPlayer(PlayerStats playerStats)
    {
        playerStats.HealthInstance = HealthInst;
        playerStats.PointsInstance = PointsInst;
        playerStats.DamageInstance = DamageInst;
        playerStats.InvincibilityInstance = InvincibilityInst;
        playerStats.CooldownInstance = CooldownInst;
    }
}
