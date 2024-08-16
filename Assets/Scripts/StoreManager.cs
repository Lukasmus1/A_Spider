using UnityEngine;

public class StoreManager : MainMenuManager
{
    public delegate void OnBuyItem();
    public static event OnBuyItem OnBuyItemEvent;

    private void Start()
    {
        OnBuyItemEvent += UpdateStatsText;

    }

    private void OnDisable()
    {
        OnBuyItemEvent = null;
    }

    public static void InvokeOnBuyItemEvent()
    {
        OnBuyItemEvent?.Invoke();
    }
}
