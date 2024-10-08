using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public bool isDead;
    
    [HideInInspector] public IEnemyStats enemyStats;
    
    //An event that will be raised when the enemy is shot in BulletScript.cs
    public delegate void EnemyShotDelegate();
    public event EnemyShotDelegate OnEnemyShot;
    
    public delegate void PlayerHitDelegate();
    public event PlayerHitDelegate OnPlayerHit;
    
    [SerializeField] private Sprite downedFlySprite;

    [SerializeField] private GameObject healthText;
    
    [SerializeField] private GameObject hitTextPrefab;
    
    public Rigidbody2D rb;
    
    private NavMeshAgent _agent;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        OnEnemyShot += EnemyShot;
        OnPlayerHit += PlayerHit;
        enemyStats = GetComponent<BasicEnemyStats>();
        EnemyUIScript enemyUIScript = Instantiate(healthText, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity).GetComponent<EnemyUIScript>();
        enemyUIScript.StartScript(gameObject, this);
        _agent = GetComponent<NavMeshAgent>();
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
    
    private void EnemyShot()
    {
        enemyStats.EnemyHealth -= (int)PlayerStats.Instance.DamageInstance.Value;
        if (isDead)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = downedFlySprite;
            _agent.enabled = false;
            rb.drag = 2f;
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isDead)
            {
                Utilities.Instance.CreateHitText(other.transform.position, "+" + enemyStats.EnemyPoints, Color.yellow);
                Destroy(gameObject);
            }
            else
            {
                if (!PlayerStats.Instance.InvincibilityInstance.IsInvincible)
                {
                    OnPlayerHit?.Invoke();
                    Utilities.Instance.CreateHitText(other.transform.position, enemyStats.EnemyDamage.ToString(), Color.red);
                }
            }
        }
    }

    private void PlayerHit()
    {
        PlayerStats.Instance.HealthInstance.Health -= enemyStats.EnemyDamage;
        PlayerStats.Instance.InvincibilityInstance.IsInvincible = true;
        UiScript.RaiseHealthChange();
    }
}
