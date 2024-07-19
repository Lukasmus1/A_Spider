using TMPro;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private float timeToLive = 1f;
    private float _timeAlive;
    
    [SerializeField] private float speed = 10f;

    [SerializeField] private Sprite downedFlySprite;
    
    [SerializeField] private GameObject hitTextPrefab;
    
    private Vector3 _direction;
    
    private void OnEnable()
    {
        _direction = player.transform.up;
        _timeAlive = 0f;
        _hit = false;
    }

    private void OnDisable()
    {
        transform.position = Vector2.zero;
    }

    private void Update()
    {
        transform.position += _direction * (speed * Time.deltaTime);

        if (_timeAlive >= timeToLive)
        {
            gameObject.SetActive(false);
        }
        else
        {
            _timeAlive += Time.deltaTime;
        }
    }

    private bool _hit;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //This is here to prevent the bullet from hitting multiple enemies at once
            //The bullet will slightly move a second after hitting an enemy in some rare cases, but it's not a big deal
            if (_hit)
            {
                return;
            }
            
            _hit = true;
            gameObject.SetActive(false);
            
            //I decided to go with the destroy/instantiate method instead of pooling
            EnemyScript enemyScript = other.gameObject.GetComponent<EnemyScript>();
            if (!enemyScript.isDead)
            {
                enemyScript.RaiseEnemyShot();
                Utilities.Instance.CreateHitText(other.transform.position, PlayerStats.Instance.Damage.ToString(), Color.red);
            }
        }
    }
    
}
