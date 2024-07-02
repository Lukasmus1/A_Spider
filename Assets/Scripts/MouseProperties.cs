using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseProperties : MonoBehaviour
{
    private MouseProperties _instance;
    public MouseProperties Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = this;
            }
            return _instance;
        }
    }
    
    public Vector2 GetMousePosition()
    {
        Vector2 mousePos = Vector2.zero;
        //mouse pos
        return mousePos;
    }
}
