using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    private CarMovement carMovement;
    public int health;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        carMovement = GetComponent<CarMovement>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact-Vehicle"))
            if(!player.activeInHierarchy)
                Exit();
                
        Health();
    }

    public void Enter()
    {
        Driver driver = player.GetComponent<Driver>();
        driver.gameObject.SetActive(false);
        carMovement.enabled = true;
    }

    public void Exit()
    {
        player.SetActive(true);
        player.transform.position = transform.position + new Vector3(2.5f,0f,0f);
        carMovement.enabled = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
         //if you want to add enemy cars, call it CarE
        if(collision.gameObject.CompareTag("Wall")||collision.gameObject.CompareTag("CarE")) 
            health -= 10;
        
        Debug.Log(collision.gameObject.name);
    }

    public void Health()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
