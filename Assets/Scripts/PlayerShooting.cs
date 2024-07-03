using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject levelManager;
    
    
    private void Awake()
    {
        levelManager.GetComponent<MouseProperties>().OnMouseClicked += Shoot;
    }
    
    private static void Shoot()
    {
        Debug.Log("Pif!");
    }
}
