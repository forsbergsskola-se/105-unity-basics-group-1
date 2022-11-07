using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var transform1 = firePoint.transform;
            Instantiate(bullet, transform1.position, transform1.rotation );
        }
    }
}

