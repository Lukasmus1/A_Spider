using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject managerPrefab;
    
    private GameObject _player;
    private EnemyScript _enemyScript;
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _enemyScript = GetComponent<EnemyScript>();
        _rb = _enemyScript.rb;
    }
    
    private void Update()
    {
        if (_player && !_enemyScript.isDead)
        {
            float angle = Utilities.Instance.GetAngleOfTwoObjects(transform, _player.transform.position);
            if (!Mathf.Approximately(angle, 1000f))
            { 
                _rb.MoveRotation(angle);   
            }
        }
    }

    private void FixedUpdate()
    {
        if (_player && !_enemyScript.isDead)
        {
            Vector2 dir = _player.transform.position - transform.position;
            _rb.MovePosition(_rb.position + dir.normalized * (speed * Time.fixedDeltaTime));
        }
    }
}
