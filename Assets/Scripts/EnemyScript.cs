using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [HideInInspector] public bool isDead = false;

    //An event that will be raised when the enemy is shot in BulletScript.cs
    public delegate void EnemyShot();
    public event EnemyShot OnEnemyShot;

    private void Awake()
    {
        OnEnemyShot += Shot;
    }

    //Remove the event when the object is destroyed
    private void OnDestroy()
    {
        OnEnemyShot = null;
    }

    //Helping method to raise the event from BulletScript.cs
    public void RaiseEnemyShot()
    {
        OnEnemyShot?.Invoke();
    }
    
    private void Shot()
    {
        isDead = true;
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isDead)
            {
                //Add points to player or smth
                Destroy(gameObject);
            }
            else
            {
                print("Player was hit");
            }
        }
    }
}
