using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreInvincibilityScript : StoreBase
{
    [SerializeField] private TMP_Text titleRef;
    [SerializeField] private TMP_Text descriptionRef;
    [SerializeField] private Image backgroundRef;
    [SerializeField] private TMP_Text backgroundTextRef;

    [SerializeField] private Sprite pictureDer;
    [SerializeField] private TMP_Text bgTextRef;
    [SerializeField] private Vector2 backgroundTextPos;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Button buyButton;

    
    private void Start()
    {
        Title = titleRef;
        Description = descriptionRef;
        Background = backgroundRef;
        BackgroundText = backgroundTextRef;
        BgTextTMP = bgTextRef;
        Picture = pictureDer;
        TitleLocalizazionKey = "invinc";
        DescriptionLocalizazionKey = "invincDesc";
        BackgroundTextPos = backgroundTextPos;
        
        PriceText = priceText;
        BuyButton = buyButton;
        StatsBase = MainMenuManager.Save.InvincibilityInst;
        UpdatePrice();
        
        StoreManager.OnBuyItemEvent += UpdatePrice;
    }

    private void OnDisable()
    {
        StoreManager.OnBuyItemEvent -= UpdatePrice;
    }
}
