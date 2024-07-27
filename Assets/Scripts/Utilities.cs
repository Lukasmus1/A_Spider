using TMPro;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    [SerializeField] private GameObject hitTextPrefab;
    
    public static Utilities Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
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
    
    public void CreateHitText(Vector3 position, string text, Color color)
    {
        GameObject hitText = Instantiate(hitTextPrefab, position, Quaternion.identity);
        hitText.GetComponent<TextMeshPro>().text = text;
        hitText.GetComponent<TextMeshPro>().color = color;
    }

    public Vector2 GetRandomVector2(float minX, float maxX, float minY, float maxY)
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        
        return new Vector2(x, y);
    }
}
