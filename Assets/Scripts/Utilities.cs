using UnityEngine;

public class Utilities
{
    private static Utilities _instance;
    public static Utilities Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Utilities();
            }
            return _instance;
        }
    }
    
    public void RotateObjectToFaceAnother(Transform objectToRotate, Vector2 targetPosition)
    {
        //This is an ugly hack to prevent the player from rotating when the game is paused
        if (Time.timeScale == 0)
            return;
        
        Vector2 mouseDir = targetPosition - (Vector2)objectToRotate.position;
        float angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
        objectToRotate.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
