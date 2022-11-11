
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    private int _selectWeapon;
    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = _selectWeapon;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _selectWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _selectWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _selectWeapon = 2;

        if (previousSelectedWeapon != _selectWeapon)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(i == _selectWeapon);
            i++;
        }
    }
}
