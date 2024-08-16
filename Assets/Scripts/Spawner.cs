using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private ArrowScript arrowPrefab;
    
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameManager gm;
    
    [SerializeField] private float spawnRate = 3f;
    private float _timeSinceLastSpawn;
    
    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= spawnRate)
        {
            _timeSinceLastSpawn = 0;
            SpawnEnemy(gm.minX, gm.maxX, gm.minY, gm.maxY);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    //This is called very few times, so it's not a performance issue
    private void SpawnEnemy(float minX, float maxX, float minY, float maxY)
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
        
        //Check if the spawn point is out of bounds
        randomPosition = CheckDistanceFromMax(randomPosition, minX, maxX, minY, maxY);
        
        GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        SetEnemyVariables(enemy.GetComponent<BasicEnemyStats>());
        enemy.SetActive(true);
        
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
    
    private static Vector2 CheckDistanceFromMax(Vector2 pos, float minX, float maxX, float minY, float maxY)
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
    
    private void SetEnemyVariables(IEnemyStats enemy)
    {
        enemy.IncreaseDifficulty(DifficultyManager.TimeMultiplier);
    }
}
