using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;

    [SerializeField] private GameObject[] bullets;
    private static int _currentBulletIndex;
    
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
            if (PlayerStats.Instance.CooldownInstance.Value > _lastShotTime)
            {
                _lastShotTime += Time.deltaTime;
                UiScript.RaiseCooldownChange(_lastShotTime);
            }
            else
            {
                _lastShotTime = 0f;
                _canShoot = true;
                UiScript.RaiseCooldownChange(_lastShotTime);
            }
        }
    }
}
