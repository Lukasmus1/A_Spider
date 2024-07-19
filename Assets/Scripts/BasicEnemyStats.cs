public class BasicEnemyStats : EnemyStats
{
    private int _enemyHealth = 10;
    public override int EnemyHealth
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
    
    public override int EnemyPoints { get; set; } = 5;
    public override int EnemyDamage { get; set; } = 5;
}
