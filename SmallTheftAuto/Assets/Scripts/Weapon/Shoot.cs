using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public Weapon weapon;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& !weapon.reload)
        {
            var transform1 = firePoint.transform;
            Instantiate(bullet, transform1.position, transform1.rotation );
            weapon.currentAmmo--;
        }
    }
}