using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    private Transform _firePoint;
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
        _firePoint = GetComponent<Transform>().GetChild(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_weapon.reload)
        {
            var transform1 = _firePoint.transform;
            Instantiate(bullet, transform1.position, transform1.rotation );
            _weapon.currentAmmo--;
        }
    }
}