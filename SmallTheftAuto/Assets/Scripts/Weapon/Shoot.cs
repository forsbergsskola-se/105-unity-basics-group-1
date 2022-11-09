using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public WeaponInfo weaponInfo;
    private Transform _firePoint;
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
        _firePoint = GetComponent<Transform>().GetChild(0);
    }

    private void Update()
    {
        //Todo: if handgun geykeydown, if machinegun getkey, if fists raycast onhit damage
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_weapon.isReloading)
        {
            var transform1 = _firePoint.transform;
            Instantiate(bullet, transform1.position, transform1.rotation );
            _weapon.currentAmmo--;
            
            weaponInfo.currentAmmo = _weapon.currentAmmo;
        }
    }
}