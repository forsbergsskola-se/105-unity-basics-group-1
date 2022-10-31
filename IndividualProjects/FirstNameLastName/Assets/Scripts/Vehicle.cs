using System;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    GameObject _player;
    public CarMovement carMovement;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (EnterCarButtonPressed())
        {
            if (PlayerIsInCar())
            {
                LeaveCar();
            }
            else if(Vector3.Distance(_player.transform.position, transform.position) < 3)
            {
                EnterCar();
            }
        }
    }
    bool EnterCarButtonPressed()
    {
        return Input.GetButtonDown("Interact-Vehicle");
    }
    bool PlayerIsInCar()
    {
        return !_player.activeInHierarchy;
    }
    void LeaveCar()
    {
        _player.transform.position = transform.position;
        _player.SetActive(true);
        carMovement.enabled = false;
    }
    void EnterCar()
    {
        _player.SetActive(false);
        carMovement.enabled = true;
    }
}
