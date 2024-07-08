using UnityEngine;

public class GameManager : LevelManager
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnCooldown = 5f;
    private float _timeSinceLastSpawn = 0f;
    
    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= spawnCooldown)
        {
            SpawnEnemy();
            _timeSinceLastSpawn = 0f;
        }    
    }
    
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, player.transform.position + new Vector3(5, 0, 0), Quaternion.identity);
    }
}
