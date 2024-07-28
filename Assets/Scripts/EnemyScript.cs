using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public bool isDead;
    
    [HideInInspector] public EnemyStats enemyStats;
    
    //An event that will be raised when the enemy is shot in BulletScript.cs
    public delegate void EnemyShotDelegate();
    public event EnemyShotDelegate OnEnemyShot;
    
    public delegate void PlayerHitDelegate();
    public event PlayerHitDelegate OnPlayerHit;
    
    [SerializeField] private Sprite downedFlySprite;

    [SerializeField] private GameObject healthText;
    
    [SerializeField] private GameObject hitTextPrefab;
    
    public Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        OnEnemyShot += EnemyShot;
        OnPlayerHit += PlayerHit;
        enemyStats = GetComponent<BasicEnemyStats>();
        EnemyUIScript enemyUIScript = Instantiate(healthText, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity).GetComponent<EnemyUIScript>();
        enemyUIScript.StartScript(gameObject, this);
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
        enemyStats.EnemyHealth -= PlayerStats.Instance.Damage;
        if (isDead)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = downedFlySprite;
            rb.drag = 1f;
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
                if (!PlayerStats.Instance.IsInvincible)
                {
                    OnPlayerHit?.Invoke();
                    Utilities.Instance.CreateHitText(other.transform.position, enemyStats.EnemyDamage.ToString(), Color.red);
                }
            }
        }
    }

    private void PlayerHit()
    {
        PlayerStats.Instance.Health -= enemyStats.EnemyDamage;
        PlayerStats.Instance.IsInvincible = true;
        UiScript.RaiseHealthChange();
    }
}
