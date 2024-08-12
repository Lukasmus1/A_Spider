using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class StoreScript : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

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
}
