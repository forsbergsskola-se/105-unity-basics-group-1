using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    private void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag("CarE"))
        {
            Vehicle car = FindObjectOfType<Vehicle>();
            car.TakeDamage(10);
        }
    }
}
