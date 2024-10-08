using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject thingToFollow;

    private readonly Vector3 _zOffset = new(0, 0, -10);
    
    private const float LerpSpeed = 5f;
    
    [SerializeField] private MouseProperties mouseProperties;
    

    private void LateUpdate()
    {
        // Calculating the dsitance and direction between the mouse and the player
        Vector3 dir = (Vector3)mouseProperties.mousePosition - thingToFollow.transform.position;
        dir.Normalize();
        
        float distance = Vector3.Distance(mouseProperties.mousePosition, thingToFollow.transform.position);
        
        //Target position will be between the player and the mouse closer to the player (Square root of distance)
        Vector3 targetPosition = thingToFollow.transform.position + _zOffset + dir * (Mathf.Sqrt(distance) * 0.5f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, LerpSpeed * Time.deltaTime);
    }
}
