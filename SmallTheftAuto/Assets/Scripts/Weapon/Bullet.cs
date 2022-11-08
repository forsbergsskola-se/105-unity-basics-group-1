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
        if (col.gameObject.CompareTag("CarE"))
        {
            Vehicle car = col.GetComponent<Vehicle>();
            car.TakeDamage(10);
        }
        
        Destroy(gameObject);
    }
    
    void OnBecameInvisible()
    {
        //Should be called when out of view in scene and/or game view
        Destroy(gameObject);
    }
}
