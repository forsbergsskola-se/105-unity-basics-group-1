using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public WeaponInfo weaponInfo;
    private Transform _firePoint;
    private Weapon _weapon;
    private float shootTimer;
    private bool _canShoot;
    
    private void Start()
    {
        _canShoot = true;
        _weapon = GetComponent<Weapon>();
        _firePoint = GetComponent<Transform>().GetChild(0);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && !_weapon.isReloading && weaponInfo.nameOfWeapon == "HandGun")
        {
            var transform1 = _firePoint.transform;
            Instantiate(bullet, transform1.position, transform1.rotation );
            _weapon.currentAmmo--;
            
            weaponInfo.currentAmmo = _weapon.currentAmmo;
        }

        if (Input.GetKey(KeyCode.Mouse0) && !_weapon.isReloading && weaponInfo.nameOfWeapon == "MachineGun")
        {
            Timer();
            if(_canShoot)
            {
                var transform1 = _firePoint.transform;
                Instantiate(bullet, transform1.position, transform1.rotation );
                _weapon.currentAmmo--;
                
                weaponInfo.currentAmmo = _weapon.currentAmmo;
                
                _canShoot = false;
                shootTimer = 0.14f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && weaponInfo.nameOfWeapon == "Fists")
        {
            var ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (hit.collider.GetComponent<Vehicle>())
                {
                    hit.collider.GetComponent<Vehicle>().TakeDamage(10);
                }
            }
            
        }
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.yellow);
    }

    private void Timer()
    {
        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;
        if(shootTimer < 0)
        {
            _canShoot = true;
        }
    }
}