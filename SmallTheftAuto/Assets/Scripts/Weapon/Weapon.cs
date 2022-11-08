
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int totalAmmo = 15;
    public int currentAmmo;
    public float timer = 2f;
    public bool reload;
    private bool _isReloading;
    
    private void Start()
    {
        currentAmmo = totalAmmo;

    }

    private void Update()
    {
        Debug.Log(currentAmmo);
        if (currentAmmo == 0)
        {
            reload = true;

            if (Input.GetKeyDown(KeyCode.R))
                _isReloading = true;
                
            
        }
        
        if(_isReloading)
            Shoot();
    }

    void Shoot()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer < 0)
        {
            reload = false;
            _isReloading = false;
            currentAmmo = 15;
            timer = 2f;
        }
    }
}

