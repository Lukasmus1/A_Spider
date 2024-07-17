using UnityEngine;
using UnityEngine.Serialization;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public bool isDead = false;
    
    [SerializeField] private Sprite downedFlySprite;

    [SerializeField] private GameObject healthText;

    //An event that will be raised when the enemy is shot in BulletScript.cs
    public delegate void EnemyShot();
    public event EnemyShot OnEnemyShot;

    public EnemyStats enemyStats;
    
    private void Awake()
    {
        OnEnemyShot += Shot;
        enemyStats = GetComponent<BasicEnemyStats>();
        EnemyUIScript enemyUIScript = Instantiate(healthText, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity).GetComponent<EnemyUIScript>();
        enemyUIScript.enemyToFollow = gameObject;
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
        enemyStats.EnemyHealth -= PlayerStats.Instance.Damage;
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
                Destroy(gameObject);
            }
            else
            {
                if (!PlayerStats.Instance.IsInvincible)
                {
                    PlayerStats.Instance.Health -= enemyStats.EnemyDamage;
                    PlayerStats.Instance.IsInvincible = true;
                    UiScript.RaiseHealthChange();
                }
            }
        }
    }
}
