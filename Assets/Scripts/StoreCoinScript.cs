using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreCoinScript : StoreBase
{
    [SerializeField] private TMP_Text titleRef;
    [SerializeField] private TMP_Text descriptionRef;
    [SerializeField] private Image backgroundRef;
    [SerializeField] private TMP_Text backgroundTextRef;

    [SerializeField] private Sprite pictureDer;
    
    private void Awake()
    {
        Title = titleRef;
        Description = descriptionRef;
        Background = backgroundRef;
        BackgroundText = backgroundTextRef;
        BgText = "";
        Picture = pictureDer;
        TitleLocalizazionKey = "coins";
        DescriptionLocalizazionKey = "coinDesc";
    }
}
