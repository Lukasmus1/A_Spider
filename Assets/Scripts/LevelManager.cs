using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public virtual void LoadScene(SceneAsset sc)
    {
        SceneManager.LoadScene(sc.name);
    }

    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void DeleteSave()
    {
        SavingSystem.DeletePlayerStats();
    }
}
