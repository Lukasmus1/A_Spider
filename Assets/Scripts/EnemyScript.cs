using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public bool isDead = false;
    
    [SerializeField] private Sprite downedFlySprite;

    //An event that will be raised when the enemy is shot in BulletScript.cs
    public delegate void EnemyShot();
    public event EnemyShot OnEnemyShot;

    private EnemyStats _enemyStats;
    
    private void Awake()
    {
        OnEnemyShot += Shot;
        _enemyStats = GetComponent<BasicEnemyStats>();
    }

    //Remove the event when the object is destroyed
    private void OnDestroy()
    {
        OnEnemyShot = null;
    }

    //Helping method to raise the event from BulletScript.cs
    public void RaiseEnemyShot()
    {
        OnEnemyShot?.Invoke();
    }
    
    private void Shot()
    {
        _enemyStats.EnemyHealth -= PlayerStats.Instance.Damage;
        if (isDead)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = downedFlySprite;
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isDead)
            {
                //Destroying the enemy will raise the OnDestroy method in BasicEnemyPrefs.cs
                Destroy(gameObject);
            }
            else
            {
                if (!PlayerStats.Instance.IsInvincible)
                {
                    PlayerStats.Instance.Health -= _enemyStats.EnemyDamage;
                    print(PlayerStats.Instance.Health);
                    PlayerStats.Instance.IsInvincible = true;
                }
            }
        }
    }
}
