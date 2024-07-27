using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private float timeToLive = 1f;
    private float _timeAlive;
    
    [SerializeField] private float speed = 10f;

    [SerializeField] private Sprite downedFlySprite;
    
    [SerializeField] private GameObject hitTextPrefab;
    
    [FormerlySerializedAs("gameManager")] [SerializeField] private GameObject gameManagerPrefab;
    
    private Vector3 _direction;
    
    private float _maxY, _minY, _maxX, _minX;
    
    private void OnEnable()
    {
        _direction = player.transform.up;
        _timeAlive = 0f;
        _hit = false;
    }

    private void Start()
    {
        GameManager gameManagerScript = gameManagerPrefab.GetComponent<GameManager>();
        _maxY = gameManagerScript.maxY + 0.2f;
        _minY = gameManagerScript.minY - 0.2f;
        _maxX = gameManagerScript.maxX + 0.2f;
        _minX = gameManagerScript.minX - 0.2f;
    }

    private void OnDisable()
    {
        transform.position = Vector2.zero;
    }

    private void Update()
    {
        transform.position += _direction * (speed * Time.deltaTime);
        
        //If alive for too long or out of bounds
        if (_timeAlive >= timeToLive || transform.position.y > _maxY || transform.position.y < _minY || transform.position.x > _maxX || transform.position.x < _minX)
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
