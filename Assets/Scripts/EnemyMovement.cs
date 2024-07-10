using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private GameObject _player;
    private EnemyScript _enemyScript;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _enemyScript = GetComponent<EnemyScript>();
    }
    
    private void Update()
    {
        if (_player && !_enemyScript.isDead)
        {
            Utilities.Instance.RotateObjectToFaceAnother(transform, _player.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
        }
    }
}
