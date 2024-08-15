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
        LoadPlayerStats();
        UpdateStatsText();
    }

    private void LoadPlayerStats()
    {
        Save = SavingSystem.LoadPlayerStats();
    }

    public void UpdateStatsText()
    {
        healthText.text = ((int)Save.HealthInst.Value).ToString();
        pointsText.text = Save.CoinsInst.Points.ToString();
        damageText.text = ((int)Save.DamageInst.Value).ToString();
        invincibilityText.text = Save.InvincibilityInst.Value.ToString("F2") + " s";
        cooldownText.text = Save.CooldownInst.Value.ToString("F2") + " s";
    }
    
    
    public override void SaveGame()
    {
        SavingSystem.SavePlayerStats(Save);
    }
    
    public override void DeleteSave()
    {
        SavingSystem.DeletePlayerStats();
        LoadPlayerStats();
    }
}
