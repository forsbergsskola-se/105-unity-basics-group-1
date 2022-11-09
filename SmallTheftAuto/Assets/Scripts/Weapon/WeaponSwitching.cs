using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectWeapon = 0;
    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = selectWeapon;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selectWeapon = 2;

        if (previousSelectedWeapon != selectWeapon)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == selectWeapon);
            i++;
            
            //Resets reload timer when switching weapon
            weapon.gameObject.GetComponent<Weapon>().ResetReload();
            /* same as above
            if( i == selectWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            */
            
            //Need the weapon reference to attack with the correct one
        }
    }
}
