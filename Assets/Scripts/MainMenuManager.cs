using TMPro;
using UnityEngine;

public class MainMenuManager : LevelManager
{
    [SerializeField] private TMP_Text healthText;
    
    [SerializeField] private TMP_Text pointsText;
    
    [SerializeField] private TMP_Text damageText;
    
    [SerializeField] private TMP_Text invincibilityText;

    [SerializeField] private TMP_Text cooldownText;

    private void Start()
    {
        LoadStatsTexts();
    }

    private void LoadStatsTexts()
    {
        PlayerStatsSave save = SavingSystem.LoadPlayerStats();

        healthText.text = save.HealthInst.MaxHealth.ToString();
        pointsText.text = save.PointsInst.Points.ToString();
        damageText.text = save.DamageInst.Damage.ToString();
        invincibilityText.text = save.InvincibilityInst.InvincibilityTime.ToString("F2") + " s";
        cooldownText.text = save.CooldownInst.ShotCooldown.ToString("F2") + " s";
    }
    
    public new void DeleteSave()
    {
        SavingSystem.DeletePlayerStats();
        LoadStatsTexts();
    }
}
