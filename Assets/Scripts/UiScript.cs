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
    
    [SerializeField] private Slider cooldownSlider;
    [SerializeField] private TMP_Text cooldownText;
    
    [SerializeField] private TMP_Text notificationText;
    
    private delegate void HealthChange();
    private static event HealthChange OnHealthChange;
    
    private delegate void PointsChange();
    private static event PointsChange OnPointsChange;
    
    private delegate void CooldownChange(float cooldown);
    private static event CooldownChange OnCooldownChange;
    
    private delegate void Notification(string message);
    private static event Notification OnNotification;
    private float _notificationTime;

    private void Awake()
    {
        OnHealthChange += UpdateHealth;
        OnPointsChange += PointsUpdate;
        OnCooldownChange += UpdateCooldown;
        OnNotification += ShowNotification;
    }

    //Start because PlayerStats.Instance is not yet set in Awake
    private void Start()
    {
        PlayerStats.Instance.OnDeath += ShowGameOverPanel;
        
        //I could call the event instead but this is safer
        UpdateHealth();
        PointsUpdate();
        
        cooldownSlider.maxValue = PlayerStats.Instance.ShotCooldown;
    }
    
    private void OnDestroy()
    {
        OnHealthChange = null;
        OnPointsChange = null;
        OnCooldownChange = null;
        OnNotification = null;
    }

    private void Update()
    {
        if (notificationText.gameObject.activeSelf)
        {
            _notificationTime += Time.deltaTime;
            if (_notificationTime >= 3)
            {
                HideNotification();
                _notificationTime = 0;
            }
        }
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
    
    private void UpdateCooldown(float cooldown)
    {
        if (cooldown == 0)
        {
            cooldownSlider.gameObject.SetActive(false);
        }
        else
        {
            //This is here to save performance
            if (!cooldownSlider.gameObject.activeSelf)
            {
                cooldownSlider.gameObject.SetActive(true);
            }
            
            cooldownSlider.value = cooldown;
            cooldownText.text = (PlayerStats.Instance.ShotCooldown - cooldown).ToString("F1");
        }
    }
    
    public static void RaiseCooldownChange(float cooldown)
    {
        OnCooldownChange?.Invoke(cooldown);
    }
    
    private void ShowNotification(string message)
    {
        notificationText.text = message;
        notificationText.gameObject.SetActive(true);
    }
    
    private void HideNotification()
    {
        notificationText.gameObject.SetActive(false);
    }
    
    public static void RaiseNotification(string message)
    {
        OnNotification?.Invoke(message);
    }
}
