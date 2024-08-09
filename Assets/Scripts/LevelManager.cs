using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        SavingSystem.DeletePlayerStats();
#endif
        Application.Quit();
    }

    public void DeleteSave()
    {
        SavingSystem.DeletePlayerStats();
    }
}
