using UnityEngine;

[CreateAssetMenu]
public class WeaponInfo : ScriptableObject
{
    public string nameOfWeapon;
    public int totalAmmo;
    public int currentAmmo;
    public bool isReloading;
}
