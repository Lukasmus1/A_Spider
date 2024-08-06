using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : LevelManager
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private GameObject arrowPrefab;
    
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject gameOverMenu;
    
    //Map boundaries
    public float maxY;
    public float minY;
    
    public float maxX;
    public float minX;


    private void Start()
    {
        TimescaleSet(1);
        PlayerStats.Instance.OnDeath += TimescaleZero;
    }

    private void OnDisable()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SavingSystem.SavePlayerStats();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverMenu.activeSelf)
        {
            PauseGame();
        }
    }
    
    //This method exists for the event OnDeath in PlayerStats.cs
    private void TimescaleZero()
    {
        Time.timeScale = 0;
    }

    private static void TimescaleSet(float time)
    {
        Time.timeScale = time;
    }
 
    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            TimescaleSet(1);
            pauseMenu.SetActive(false);
        }
        else
        {
            TimescaleSet(0);
            pauseMenu.SetActive(true);
        }
    }
}
