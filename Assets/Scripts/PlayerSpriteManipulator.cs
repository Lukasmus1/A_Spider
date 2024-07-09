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
        Utilities.Instance.RotateObjectToFaceAnother(transform, _mouseProperties.mousePosition);
    }
}
