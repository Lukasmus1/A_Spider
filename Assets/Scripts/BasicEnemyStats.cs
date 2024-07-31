using UnityEngine;

public class BasicEnemyStats : MonoBehaviour, IEnemyStats
{
    private int _enemyHealth = 10;
    public int EnemyHealth
    {
        get => _enemyHealth;
        set
        {
            _enemyHealth = value;
            if (_enemyHealth <= 0)
            {
                GetComponent<EnemyScript>().isDead = true;
                _enemyHealth = 0;
            }
        }
    }
    
    public int EnemyPoints { get; set; } = 5;
    public int EnemyDamage { get; set; } = 5;
    public void OnDestroy()
    {
        PlayerStats.Instance.Points += EnemyPoints;
        UiScript.RaisePointsChange();
    }
}
