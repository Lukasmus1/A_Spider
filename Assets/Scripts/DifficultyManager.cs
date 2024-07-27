using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private float timeToIncreaseDifficulty = 10f;
    
    [SerializeField] private BasicEnemyStats enemyStats;
    
    private float _time = 0f;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= timeToIncreaseDifficulty)
        {
            IncreaseDifficulty();
            _time = 0f;
        }
    }

    private void IncreaseDifficulty()
    {
        enemyStats.EnemyHealth += 10;
        enemyStats.EnemyDamage += 5;
        enemyStats.EnemyPoints += 5;
    }
}
