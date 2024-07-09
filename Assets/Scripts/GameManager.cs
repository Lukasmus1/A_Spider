using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : LevelManager
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnCooldown = 5f;
    private float _timeSinceLastSpawn = 0f;
    
    [SerializeField] private GameObject arrowPrefab;
    
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
        //This must be random, not new Vector3(5, 0, 0)
        GameObject enemy = Instantiate(enemyPrefab, player.transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        ArrowScript arrowScript = Instantiate(arrowPrefab, player.transform).GetComponent<ArrowScript>();;
        arrowScript.SetVariables(enemy);
    }
}
