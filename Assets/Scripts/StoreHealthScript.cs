using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreHealthScript : StoreBase
{
    [SerializeField] private TMP_Text titleRef;
    [SerializeField] private TMP_Text descriptionRef;
    [SerializeField] private Image backgroundRef;
    [SerializeField] private TMP_Text backgroundTextRef;
    
    [SerializeField] private TMP_Text bgTextDer;
    [SerializeField] private Sprite pictureDer;
    [SerializeField] private Vector2 backgroundTextPos;
    [SerializeField] private TMP_Text priceText;
    
    private void OnEnable()
    {
        Title = titleRef;
        Description = descriptionRef;
        Background = backgroundRef;
        BackgroundText = backgroundTextRef;
        BgTextTMP = bgTextDer;
        Picture = pictureDer;
        TitleLocalizazionKey = "health";
        DescriptionLocalizazionKey = "healthDesc";
        BackgroundTextPos = backgroundTextPos;
        
        PriceText = priceText;
        Price = MainMenuManager.Save.HealthInst;
        UpdatePrice();
    }
}
