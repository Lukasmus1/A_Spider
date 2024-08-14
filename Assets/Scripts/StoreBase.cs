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
    protected string BgText;
    protected Sprite Picture;
    protected string TitleLocalizazionKey;
    protected string DescriptionLocalizazionKey;
    protected Vector2 BackgroundTextPos;
    
    private void DisplayTitle()
    {
        Title.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(TitleLocalizazionKey).Result;
    }
    
    private void DisplayDescription()
    {
        Description.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(DescriptionLocalizazionKey).Result;
    }
    
    public void HideTitleAndDescription()
    {
        Title.text = "";
        Description.text = "";
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
}
