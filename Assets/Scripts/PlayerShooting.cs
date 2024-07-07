using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject levelManager;

    [SerializeField] 
    private GameObject[] bullets;
    private static int _currentBulletIndex = 0;
    
    private const float Cooldown = 0.5f;
    private float _lastShotTime;
    private bool _canShoot = true;
    
    private void Awake()
    {
        levelManager.GetComponent<MouseProperties>().OnMouseClicked += Shoot;
    }
    
    private void Shoot()
    {
        if (_canShoot)
        {
            if (_currentBulletIndex >= bullets.Length)
            {
                _currentBulletIndex = 0;
            }
         
            //Enabling a bullet and setting its position
            bullets[_currentBulletIndex].SetActive(true);
            bullets[_currentBulletIndex].transform.position = transform.position + transform.up * 0.5f;
            
            _canShoot = false;
            _currentBulletIndex++;
        }
    }

    private void Update()
    {
        //This is here for a cooldown between shots
        if (!_canShoot)
        {
            if (Cooldown > _lastShotTime)
            {
                _lastShotTime += Time.deltaTime;
            }
            else
            {
                _lastShotTime = 0f;
                _canShoot = true;
            }
        }
    }
}
