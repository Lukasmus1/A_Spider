using TMPro;
using UnityEngine;

public class MainMenuManager : LevelManager
{
    [SerializeField] private TMP_Text healthText;
    
    [SerializeField] private TMP_Text pointsText;
    
    [SerializeField] private TMP_Text damageText;
    
    [SerializeField] private TMP_Text invincibilityText;

    [SerializeField] private TMP_Text cooldownText;

    public static PlayerStatsSave Save;
    
    private void Awake()
    {
        LoadStatsTexts();
    }

    private void LoadStatsTexts()
    {
        Save = SavingSystem.LoadPlayerStats();

        healthText.text = Save.HealthInst.MaxHealth.ToString();
        pointsText.text = Save.CoinsInst.Points.ToString();
        damageText.text = Save.DamageInst.Damage.ToString();
        invincibilityText.text = Save.InvincibilityInst.InvincibilityTime.ToString("F2") + " s";
        cooldownText.text = Save.CooldownInst.ShotCooldown.ToString("F2") + " s";
    }
    
    public new void DeleteSave()
    {
        SavingSystem.DeletePlayerStats();
        LoadStatsTexts();
    }
}
