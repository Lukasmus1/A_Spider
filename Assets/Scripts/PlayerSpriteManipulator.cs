using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManipulator : MonoBehaviour
{
    [SerializeField]
    private GameObject levelManager;

    private MouseProperties _mouseProperties;

    private void Awake()
    {
        _mouseProperties = levelManager.GetComponent<MouseProperties>();
    }

    void Update()
    {
        Vector2 mouseDir = _mouseProperties.mousePosition - (Vector2)transform.position;
        float angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
