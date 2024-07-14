using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseProperties : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    [HideInInspector] public Vector2 mousePosition = Vector2.zero;
    
    //Mouse click event
    public delegate void MouseClicked();
    public event MouseClicked OnMouseClicked;

    private void OnDestroy()
    {
        OnMouseClicked = null;
    }

    private void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        //Time.timeScale != 0 is to prevent the player from clicking when the game is paused
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            //ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            //Disabled because you need to click to call this
            OnMouseClicked?.Invoke();
        }
    }
}
