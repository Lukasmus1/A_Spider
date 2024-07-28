using UnityEngine;

public class PlayerSpriteManipulator : MonoBehaviour
{
    [SerializeField]
    private GameObject levelManager;

    private MouseProperties _mouseProperties;

    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _mouseProperties = levelManager.GetComponent<MouseProperties>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float angle = Utilities.Instance.GetAngleOfTwoObjects(transform, _mouseProperties.mousePosition);
        if (!Mathf.Approximately(angle, 1000f))
        { 
            _rb.MoveRotation(angle);   
        }
    }
}
