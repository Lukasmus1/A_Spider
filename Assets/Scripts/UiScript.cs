using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    
    public delegate void HealthChange();
    public static event HealthChange OnHealthChange;
    
    //Start because PlayerStats.Instance is not yet set in Awake
    private void Start()
    {
        OnHealthChange += UpdateHealth;
        
        //I could call the event instead but this is safer
        UpdateHealth();
    }

    private void OnDestroy()
    {
        OnHealthChange = null;
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
}
