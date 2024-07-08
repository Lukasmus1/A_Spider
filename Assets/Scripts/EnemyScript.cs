using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public bool isDead = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isDead)
            {
                //Add points to player or smth
                Destroy(gameObject);
            }
            else
            {
                print("Player was hit");
            }
        }
    }
}
