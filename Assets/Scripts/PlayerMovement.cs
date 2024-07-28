using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private GameManager gameManager;

    private Rigidbody2D _rb;

    private Vector2 _dir;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = -1;
    }

    private void Update()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");

        /*Vector3 dir = new(_horizontal, _vertical, 0);
        Vector3 pos = transform.position + dir.normalized * (speed * Time.deltaTime);

        transform.position = pos;*/
        
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _dir.normalized * (speed * Time.fixedDeltaTime));
    }
}
