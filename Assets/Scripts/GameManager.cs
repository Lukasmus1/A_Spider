using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : LevelManager
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnCooldown = 5f;
    private float _timeSinceLastSpawn = 0f;
    
    [SerializeField] private GameObject arrowPrefab;
    
    [SerializeField] private GameObject pauseMenu;
    
    [SerializeField] private GameObject gameOverMenu;


    private void Start()
    {
        TimescaleSet(1);
        PlayerStats.Instance.OnDeath += TimescaleZero;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= spawnCooldown)
        {
            SpawnEnemy();
            _timeSinceLastSpawn = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverMenu.activeSelf)
        {
            PauseGame();
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    //This is called very few times, so it's not a performance issue
    private void SpawnEnemy()
    {
        //This must be random, not new Vector3(5, 0, 0)
        GameObject enemy = Instantiate(enemyPrefab, player.transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        ArrowScript arrowScript = Instantiate(arrowPrefab, player.transform).GetComponent<ArrowScript>();;
        arrowScript.SetVariables(enemy);
    }
 
    //This method exists for the event OnDeath in PlayerStats.cs
    private void TimescaleZero()
    {
        Time.timeScale = 0;
    }

    private void TimescaleSet(float time)
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
