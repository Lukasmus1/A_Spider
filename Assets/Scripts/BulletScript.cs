using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    [SerializeField]
    private float timeToLive = 1f;
    private float _timeAlive;
    
    [SerializeField]
    private float speed = 10f;
    
    private Vector3 _direction;
    
    private void OnEnable()
    {
        _direction = player.transform.up;
        _timeAlive = 0f;
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
}
