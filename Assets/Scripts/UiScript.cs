using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    
    [SerializeField] private TMP_Text pointsText;
    
    [SerializeField] private GameObject gameOverPanel;
    
    public delegate void HealthChange();
    public static event HealthChange OnHealthChange;
    
    public delegate void PointsChange();
    public static event PointsChange OnPointsChange;
    
    //Start because PlayerStats.Instance is not yet set in Awake
    private void Start()
    {
        OnHealthChange += UpdateHealth;
        OnPointsChange += PointsUpdate;
        PlayerStats.Instance.OnDeath += ShowGameOverPanel;
        
        //I could call the event instead but this is safer
        UpdateHealth();
        PointsUpdate();
    }

    private void OnDestroy()
    {
        OnHealthChange = null;
        OnPointsChange = null;
    }

    private void UpdateHealth()
    {
        healthSlider.value = PlayerStats.Instance.Health;
        healthText.text = PlayerStats.Instance.Health.ToString();
    }
    
    public static void RaiseHealthChange()
    {
        OnHealthChange?.Invoke();
    }
    
    private void PointsUpdate()
    {
        pointsText.text = PlayerStats.Instance.Points.ToString();
    }
    
    public static void RaisePointsChange()
    {
        OnPointsChange?.Invoke();
    }
    
    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
