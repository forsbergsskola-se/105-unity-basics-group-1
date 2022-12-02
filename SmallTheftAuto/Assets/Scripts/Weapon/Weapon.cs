
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
        ResetWeapons();
        weaponInfo.currentAmmo = currentAmmo = totalAmmo;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != totalAmmo)
            isReloading = true;
        
        //Cant reload on full clip and reloads when pushed R while ammo in gun and auto reloads when ammo = 0 and if total ammo == 0 so fist dont reload
        if (totalAmmo != 0 && currentAmmo == 0 || isReloading && currentAmmo != totalAmmo)
        {
            isReloading = true;
            Reloading();
        }

        //show or hide reload circle (should be changed to reloadBar or something)
        healthBar.transform.parent.gameObject.SetActive(isReloading);
    }

    private void ResetWeapons()
    {
        //This needs to reset when changing weapons else he keeps reloading when we switch back
        isReloading = false;
        weaponInfo.isReloading = isReloading;
        reloadTimer = 2;
        
        //Updates UI when weapons is active
        weaponInfo.nameOfWeapon = GetComponent<Transform>().name;
        weaponInfo.totalAmmo = totalAmmo;
        weaponInfo.currentAmmo = currentAmmo;
        
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
        
        weaponInfo.isReloading = this.isReloading;
    }

    private void OnEnable()
    {
        ResetWeapons();
    }
}

