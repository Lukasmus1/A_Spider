using System;

//This class is here because Unity's serialization doesn't work on classes that derive from MonoBehaviour
[Serializable]
public class PlayerStatsSave
{
    private const int MaxHealth = 100;
    private int _points = 0;
    private int _damage = 10;
    private float _invincibilityTime = 0.5f;

    public void SetVars(PlayerStats playerStats)
    {
        playerStats.MaxHealth = MaxHealth;
        _points = playerStats.Points;
        _damage = playerStats.Damage;
        _invincibilityTime = playerStats.InvincibilityTime;
    }
    
    public void GetVars(PlayerStats playerStats)
    {
        playerStats.MaxHealth = MaxHealth;
        playerStats.Points = _points;
        playerStats.Damage = _damage;
        playerStats.InvincibilityTime = _invincibilityTime;
    }
}
