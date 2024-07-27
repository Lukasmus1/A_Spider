using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject managerPrefab;
    private float _maxY, _minY, _maxX, _minX;
    
    private GameObject _player;
    private EnemyScript _enemyScript;
    
    private void Awake()
    {
        GameManager gameManagerScript = managerPrefab.GetComponent<GameManager>();
        _maxY = gameManagerScript.maxY;
        _minY = gameManagerScript.minY;
        _minX = gameManagerScript.minX;
        _maxX = gameManagerScript.maxX;
        
        _player = GameObject.FindWithTag("Player");
        _enemyScript = GetComponent<EnemyScript>();
    }
    
    private void Update()
    {
        if (_player && !_enemyScript.isDead)
        {
            Utilities.Instance.RotateObjectToFaceAnother(transform, _player.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
            
            if (transform.position.y > _maxY)
            {
                transform.position = new Vector2(transform.position.x, _maxY);
            }
            else if (transform.position.y < _minY)
            {
                transform.position = new Vector2(transform.position.x, _minY);
            }
            
            if (transform.position.x > _maxX)
            {
                transform.position = new Vector2(_maxX, transform.position.y);
            }
            else if (transform.position.x < _minX)
            {
                transform.position = new Vector2(_minX, transform.position.y);
            }
        }
    }
}
