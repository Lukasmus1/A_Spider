using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : LevelManager
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnCooldown = 5f;
    private float _timeSinceLastSpawn = 0f;
    
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
        Vector2 randomPosition = Utilities.Instance.GetRandomVector2(minX, maxX, minY, maxY);
        if (randomPosition.x < player.transform.position.x + 5 && randomPosition.x > player.transform.position.x - 5)
        {
            //If the random position is too close to the player, move it to the right or left
            CheckDistanceToPlayer(ref randomPosition.x, maxX, minX);
        }
        
        if (randomPosition.y < player.transform.position.y + 5 && randomPosition.y > player.transform.position.y - 5)
        {
            //If the random position is too close to the player, move it up or down
            CheckDistanceToPlayer(ref randomPosition.y, maxY, minY);
        }
        
        
        GameObject enemy = Instantiate(enemyPrefab, player.transform.position + (Vector3)randomPosition, Quaternion.identity);
        ArrowScript arrowScript = Instantiate(arrowPrefab, player.transform).GetComponent<ArrowScript>();
        arrowScript.SetVariables(enemy);
    }

    private static void CheckDistanceToPlayer(ref float pos, float max, float min)
    {
        if (Random.Range(0, 1) == 0)
        {
            pos += 10;
            if (pos > max)
            {
                pos -= 20;
            }
        }
        else
        {
            pos -= 10;
            if (pos < min)
            {
                pos += 20;
            }
        }
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
