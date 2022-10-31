using System;
using UnityEngine;

public class Vehicle : MonoBehaviour {
    public GameObject player;
    public CarMovement carMovement;
    
    bool EnterCarButtonPressed => Input.GetButtonDown("Interact-Vehicle");
    void TogglePlayerActive() => player.SetActive(!player.activeInHierarchy);
    void ToggleCarActive() => carMovement.enabled = !carMovement.enabled;

    public void Update() {
        if (EnterCarButtonPressed)
            Exit();
    }
    
    void Exit() {
        Enter();
    }
    
    public void Enter() {
        player.transform.position = transform.position;
        TogglePlayerActive();
        ToggleCarActive();
    }

}
