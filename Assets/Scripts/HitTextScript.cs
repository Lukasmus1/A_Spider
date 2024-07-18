using UnityEngine;

public class HitTextScript : MonoBehaviour
{
    private float _timeAlive;
    private void Update()
    {
        if (_timeAlive >= 1f)
        {
            Destroy(gameObject);
        }
        else
        {
            _timeAlive += Time.deltaTime;
        }
        transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;       
    }
}
