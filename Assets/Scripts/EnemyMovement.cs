using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;
    private EnemyScript _enemyScript;
    private Rigidbody2D _rb;
    private NavMeshAgent _agent;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _enemyScript = GetComponent<EnemyScript>();
        _rb = _enemyScript.rb;
        
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }
    
    private void Update()
    {
        if (_player && !_enemyScript.isDead)
        {
            float angle = Utilities.Instance.GetAngleOfTwoObjects(transform, _player.transform.position);
            if (!Mathf.Approximately(angle, 1000f))
            { 
                _rb.MoveRotation(angle);   
            }
            _agent.SetDestination(_player.transform.position);
        }
    }
}
