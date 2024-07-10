using System;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [HideInInspector] public GameObject target;

    [SerializeField] private Sprite downedArrowSprite;
    
    private SpriteRenderer _spriteRenderer;
    private EnemyScript _enemyScript;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Wanted to do this in Awake but the target was not yet set (GameManager.cs SpawnEnemy() method)
    public void SetVariables(GameObject enemyTarget)
    {
        target = enemyTarget;
        _enemyScript = enemyTarget.GetComponent<EnemyScript>();
        _enemyScript.OnEnemyShot += ChangeArrowSprite;
    }
    
    private void ChangeArrowSprite()
    {
        _spriteRenderer.sprite = downedArrowSprite;
    }

    private void LateUpdate()
    {
        if (!target)
        {
            Destroy(gameObject);
        }
        else
        {
            Utilities.Instance.RotateObjectToFaceAnother(transform, target.transform.position);
            
            Vector2 dir = target.transform.position - transform.parent.position;
            float distance = dir.magnitude;

            const float offset = 0.5f;
            
            //If a person is close enough, the arrow will not be visible
            _spriteRenderer.enabled = !(distance < 1.5f + offset);
            
            //Square root of distance to limit the arrow's max distance
            dir.Normalize();
            transform.position = (Vector3)dir * (Mathf.Sqrt(distance) - offset)+ transform.parent.position;
        }
    }
}
