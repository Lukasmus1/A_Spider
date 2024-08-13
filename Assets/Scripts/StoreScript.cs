using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    [SerializeField] private Image background;
    [SerializeField] private TMP_Text backgroundText;

    public void DisplayTitle(string titleLocalizazionKey)
    {
        title.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(titleLocalizazionKey).Result;
    }
    
    public void DisplayDescription(string descriptionLocalizazionKey)
    {
        description.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(descriptionLocalizazionKey).Result;
    }
    
    public void HideTitleAndDescription()
    {
        title.text = "";
        description.text = "";
    }

    public void ChangeBackground(Sprite picture)
    {
        background.sprite = picture;
    }

    public void ChangeBackgroundText(TMP_Text text)
    {
        print(text.text);
        backgroundText.text = text.text;
    }
    
    public void ChangeBackgroundText(string text)
    {
        backgroundText.text = text;
    }
    
}
