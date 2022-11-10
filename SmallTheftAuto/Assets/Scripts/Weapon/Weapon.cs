using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public int totalAmmo;
    public int currentAmmo;
    public float reloadTimer = 2f;
    public bool isReloading;
    
    //Test UI Reload
    public Image healthBar;
    
    private void Start()
    {
        weaponInfo.currentAmmo = currentAmmo = totalAmmo;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != totalAmmo)
            isReloading = true;
        
        //Cant reload on full clip and reloads when pushed R while ammo in gun and auto reloads when ammo = 0
        if (totalAmmo != 0 && currentAmmo == 0 || isReloading && currentAmmo != totalAmmo)
        {
            isReloading = true;
            Reloading();
        }

        //show or hide reload circle
        healthBar.transform.parent.gameObject.SetActive(isReloading);
        
        //Change to when changing weapons
        weaponInfo.totalAmmo = totalAmmo;
        weaponInfo.currentAmmo = currentAmmo;
        //weaponInfo.nameOfWeapon = GetComponent<Transform>().GetChild(0).name;
        weaponInfo.nameOfWeapon = GetComponent<Transform>().name;
    }

    public void ResetReload()
    {
        //This needs to reset when changing weapons else he keeps reloading when we switch back
        isReloading = false;
        reloadTimer = 2;
    }

    private void Reloading()
    {
        healthBar.fillAmount = reloadTimer / 2f;

        if (reloadTimer > 0)
            reloadTimer -= Time.deltaTime;
        if(reloadTimer < 0)
        {
            isReloading = false;
            currentAmmo = totalAmmo;
            reloadTimer = 2f;
            weaponInfo.currentAmmo = totalAmmo;
        }
    }
}

