using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject thingToFollow;

    [SerializeField] 
    private Vector3 offset = new(0, 0, -10);
    
    [SerializeField]
    private float lerpSpeed = 10f;
    
    private void LateUpdate()
    {
        Vector3 targetPosition = thingToFollow.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
