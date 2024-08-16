using System;

//This class is here because Unity's serialization doesn't work on classes that derive from MonoBehaviour
[Serializable]
public class ClassToSave
{
    public HealthClass HealthInst { get; set; } = new HealthClass();
    public CoinsClass CoinsInst { get; private set; } = new CoinsClass();
    public DamageClass DamageInst { get; private set; } = new DamageClass();
    public InvincibilityClass InvincibilityInst { get; private set; } = new InvincibilityClass();
    public CooldownScript CooldownInst { get; private set; } = new CooldownScript();
    
    //This is a multiplier that is used to increase the difficulty of the game
    public DifficultyClass DifficultyInst { get; set; } = new DifficultyClass();

    public void SetVars(PlayerStats playerStats)
    {
        HealthInst = playerStats.HealthInstance;
        CoinsInst = playerStats.CoinsInstance;
        DamageInst = playerStats.DamageInstance;
        InvincibilityInst = playerStats.InvincibilityInstance;
        CooldownInst = playerStats.CooldownInstance;
        DifficultyInst = DifficultyManager.DefaultDifficultyModifier;
    }

    public void SetVars(ClassToSave classTo)
    {
        HealthInst = classTo.HealthInst;
        CoinsInst = classTo.CoinsInst;
        DamageInst = classTo.DamageInst;
        InvincibilityInst = classTo.InvincibilityInst;
        CooldownInst = classTo.CooldownInst;
        DifficultyInst = classTo.DifficultyInst;
    }
    
    public void LoadVarsToPlayer(PlayerStats playerStats)
    {
        playerStats.HealthInstance = HealthInst;
        playerStats.CoinsInstance = CoinsInst;
        playerStats.DamageInstance = DamageInst;
        playerStats.InvincibilityInstance = InvincibilityInst;
        playerStats.CooldownInstance = CooldownInst;
        DifficultyManager.DefaultDifficultyModifier = DifficultyInst;
    }
}
