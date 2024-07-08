using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseProperties : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    
    [HideInInspector]
    public Vector2 mousePosition = Vector2.zero;
    
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
        if (Input.GetMouseButtonDown(0))
        {
            //ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            OnMouseClicked?.Invoke();
        }
    }
}
