using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Weapon : MonoBehaviour
{
    public int totalAmmo = 15;
    public int currentAmmo;
    public float timer = 2f;
    public bool reload;
    
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
            Shoot();
            
        }
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
            currentAmmo = 15;
            timer = 2f;
        }
    }
}

