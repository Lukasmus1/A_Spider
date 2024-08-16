using TMPro;
using UnityEngine;

public class MainMenuManager : LevelManager
{
#if UNITY_EDITOR
    [SerializeField] protected bool debugCoins;
#endif
    
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text invincibilityText;
    [SerializeField] private TMP_Text cooldownText;
    [SerializeField] private TMP_Text difficultyText;
    

    public static ClassToSave Save;
    
    private void Awake()
    {
        LoadPlayerStats();
        UpdateStatsText();
    }

    private void LoadPlayerStats()
    {
        Save = SavingSystem.LoadPlayerStats();
#if UNITY_EDITOR
        if (debugCoins)
        {
            Save.CoinsInst.Points = 1000000;
        }
#endif
    }

    public void UpdateStatsText()
    {
        healthText.text = ((int)Save.HealthInst.Value).ToString();
        pointsText.text = Save.CoinsInst.Points.ToString();
        damageText.text = ((int)Save.DamageInst.Value).ToString();
        invincibilityText.text = Save.InvincibilityInst.Value.ToString("F2") + " s";
        cooldownText.text = Save.CooldownInst.Value.ToString("F2") + " s";
        difficultyText.text = Save.DifficultyInst.Value + " x";
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
