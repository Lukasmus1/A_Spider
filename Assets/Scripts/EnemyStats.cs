using UnityEngine;

public abstract class EnemyStats : MonoBehaviour
{
    public virtual int EnemyHealth { get; set; }
    public virtual int EnemyPoints { get; set; }
    public virtual int EnemyDamage { get; set; }
    
    private void OnDestroy()
    {
        PlayerStats.Instance.Points += EnemyPoints;
    }
}
