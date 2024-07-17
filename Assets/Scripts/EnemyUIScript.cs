using TMPro;
using UnityEngine;

//This could have been done much better if I didn't manipulate the transform of the enemy directly, but manipulated its children instead. 
//Basically the rotation was the problem, because the text was rotating with the enemy, which was not the desired effect.
public class EnemyUIScript : MonoBehaviour
{
    [HideInInspector] public GameObject enemyToFollow;
    
    private EnemyScript _enemyScript;
    private TextMeshPro _tmp;

    private void Start()
    {
        _tmp = GetComponent<TextMeshPro>();
        _enemyScript = enemyToFollow.GetComponent<EnemyScript>();
        _enemyScript.OnEnemyShot += UpdateText;
        UpdateText();
    }

    private void LateUpdate()
    {
        if (enemyToFollow)
        {
            transform.position = enemyToFollow.transform.position + new Vector3(0, 1f, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateText()
    {
        _tmp.text = _enemyScript.enemyStats.EnemyHealth.ToString();
        if (_tmp.text == "0")
        {
            Destroy(gameObject);
        }
    }
}
