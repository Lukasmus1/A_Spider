using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public virtual void LoadScene(string sc)
    {
        SceneManager.LoadScene(sc);
    }

    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public virtual void SaveGame()
    {
        SavingSystem.SavePlayerStats();
    }
    
    public virtual void DeleteSave()
    {
        SavingSystem.DeletePlayerStats();
    }
}
