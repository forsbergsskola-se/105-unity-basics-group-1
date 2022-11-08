
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public int totalAmmo = 15;
    public int currentAmmo;
    public float timer = 2f;
    public bool reload;
    private bool _isReloading;
    
    private void Start()
    {
        weaponInfo.currentAmmo = currentAmmo = totalAmmo;
    }

    private void Update()
    {
        if (currentAmmo == 0)
        {
            reload = true;
            if (Input.GetKeyDown(KeyCode.R))
                _isReloading = true;
        }
        
        if(_isReloading)
            Shoot();

        //Change to when changing weapons
        weaponInfo.totalAmmo = totalAmmo;
        //weaponInfo.nameOfWeapon = GetComponent<Transform>().GetChild(0).name;
        weaponInfo.nameOfWeapon = GetComponent<Transform>().name;

    }

    void Shoot()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if(timer < 0)
        {
            reload = false;
            _isReloading = false;
            currentAmmo = 15;
            timer = 2f;
            weaponInfo.currentAmmo = totalAmmo;
        }
    }
}

