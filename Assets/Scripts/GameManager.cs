using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : LevelManager
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnCooldown = 5f;
    private float _timeSinceLastSpawn;
    
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
        SavingSystem.SavePlayerStats();
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
    //Should move spawming to a separate script
    private void SpawnEnemy()
    {
        Vector2 randomPosition = Utilities.Instance.GetRandomVector2(minX, maxX, minY, maxY);
        if (randomPosition.x < player.transform.position.x + 10 && randomPosition.x > player.transform.position.x - 10)
        {
            //If the random position is too close to the player, move it to the right or left
            MoveFromPlayer(ref randomPosition.x);
        }
        
        if (randomPosition.y < player.transform.position.y + 10 && randomPosition.y > player.transform.position.y - 10)
        {
            //If the random position is too close to the player, move it up or down
            MoveFromPlayer(ref randomPosition.y);
        }
        
        randomPosition = CheckDistanceFromMax(randomPosition);
        
        GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        ArrowScript arrowScript = Instantiate(arrowPrefab, player.transform).GetComponent<ArrowScript>();
        arrowScript.SetVariables(enemy);
    }

    private static void MoveFromPlayer(ref float pos)
    {
        if (Random.Range(0, 2) == 0)
        {
            pos += 10;
        }
        else
        {
            pos -= 10;
        }
    }
    
    private Vector2 CheckDistanceFromMax(Vector2 pos)
    {
        if (pos.x > maxX)
        {
            pos.x = maxX - 2;
        }
        else if (pos.x < minX)
        {
            pos.x = minX + 2;
        }
        
        if (pos.y > maxY)
        {
            pos.y = maxY - 2;
        }
        else if (pos.y < minY)
        {
            pos.y = minY + 2;
        }
        
        return pos;
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
