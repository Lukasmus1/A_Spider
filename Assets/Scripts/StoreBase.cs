using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class StoreBase : MonoBehaviour
{
    //These 4 referenced are all the same in every store script, don't know how to set them here so I wouldn't have to set them in every script
    protected TMP_Text Title;
    protected TMP_Text Description;
    protected Image Background;
    protected TMP_Text BackgroundText;

    protected TMP_Text BgTextTMP;
    protected TMP_Text PriceText;
    protected IPlayerStats Price;
    protected Sprite Picture;
    protected Vector2 BackgroundTextPos;
    protected string BgText;
    protected string TitleLocalizazionKey;
    protected string DescriptionLocalizazionKey;
    
    
    private void DisplayTitle()
    {
        Title.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(TitleLocalizazionKey).Result;
    }
    
    private void DisplayDescription()
    {
        Description.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(DescriptionLocalizazionKey).Result;
    }
    
    private void ChangeBackground()
    {
        Background.sprite = Picture;
    }
    
    private void ChangeBackgroundText()
    {
        if (BgTextTMP != null)
        {
            BackgroundText.text = BgTextTMP.text;
        }
        else
        {
            BackgroundText.text = BgText;
        }
    }

    private void ChangeBackgroundTextPos()
    {
        BackgroundText.rectTransform.anchoredPosition = BackgroundTextPos;
    }
    
    public void OnHover()
    {
        DisplayTitle();
        DisplayDescription();
        ChangeBackground();
        ChangeBackgroundText();
        ChangeBackgroundTextPos();
    }

    public void UpdatePrice()
    {
        PriceText.text = Price.PriceToUpgrade.ToString();
        
        PriceText.color = Price.PriceToUpgrade > MainMenuManager.Save.CoinsInst.Points ? Color.red : Color.green;
    }
}
