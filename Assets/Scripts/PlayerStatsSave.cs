using System;

//This class is here because Unity's serialization doesn't work on classes that derive from MonoBehaviour
[Serializable]
public class PlayerStatsSave
{
    public int MaxHealth { get; private set; } = 100;
    public int Points { get; private set; } = 0;
    public int Damage { get; private set; } = 10;
    public float InvincibilityTime { get; private set; } = 0.5f;
    public float ShotCooldown { get; private set; } = 1.5f;

    public void SetVars(PlayerStats playerStats)
    {
        playerStats.MaxHealth = MaxHealth;
        Points = playerStats.Points;
        Damage = playerStats.Damage;
        InvincibilityTime = playerStats.InvincibilityTime;
        ShotCooldown = playerStats.ShotCooldown;
    }
    
    /*public PlayerStatsSave LoadVars(PlayerStatsSave playerStats)
    {
        playerStats.MaxHealth = MaxHealth;
        playerStats.Points = Points;
        playerStats.Damage = Damage;
        playerStats.InvincibilityTime = InvincibilityTime;
        playerStats.ShotCooldown = ShotCooldown;
        
        return playerStats;
    }*/
    
    public void LoadVarsToPlayer(PlayerStats playerStats)
    {
        playerStats.MaxHealth = MaxHealth;
        playerStats.Points = Points;
        playerStats.Damage = Damage;
        playerStats.InvincibilityTime = InvincibilityTime;
        playerStats.ShotCooldown = ShotCooldown;
    }
}
