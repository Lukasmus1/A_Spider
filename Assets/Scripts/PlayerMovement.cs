using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private GameManager gameManager;
    
    //Map boundaries
    private float _maxY;
    private float _minY;
    
    private float _maxX;
    private float _minX;
    
    private void Start()
    {
        //Saving the boundaries locally to avoid referencing the GameManager every frame
        _maxY = gameManager.maxY;
        _minY = gameManager.minY;
        _maxX = gameManager.maxX;
        _minX = gameManager.minX;        
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new(horizontal, vertical, 0);
        Vector3 pos = transform.position + dir.normalized * (speed * Time.deltaTime);

        //Limiting where the player can go
        if (pos.y > _maxY)
        {
            pos.y = _maxY;
        }
        else if (pos.y < _minY)
        {
            pos.y = _minY;
        }
        
        if (pos.x > _maxX)
        {
            pos.x = _maxX;
        }
        else if (pos.x < _minX)
        {
            pos.x = _minX;
        }

        transform.position = pos;
    }
}
