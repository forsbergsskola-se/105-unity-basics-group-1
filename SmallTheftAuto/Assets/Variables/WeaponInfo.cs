using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class WeaponInfo : ScriptableObject
{
    public string nameOfWeapon;
    public int totalAmmo;
    public int currentAmmo;
    
    public void GetName()
    {
        // nameOfWeapon = GameObject.FindObjectOfType<>().name;
        totalAmmo = FindObjectOfType<Weapon>().GetComponent<Weapon>().totalAmmo;
    }
}
