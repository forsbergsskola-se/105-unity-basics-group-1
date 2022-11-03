using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    private CarMovement carMovement;

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
}