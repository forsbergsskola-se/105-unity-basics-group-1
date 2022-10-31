using System;
using UnityEngine;

public class Driver : MonoBehaviour {
    [SerializeField] Vehicle car;
    bool EnterCarButtonPressed => Input.GetButtonDown("Interact-Vehicle");
    
    private void Update() {
        if (EnterCarButtonPressed && Vector3.Distance(transform.position, car.transform.position) < 2)
            car.Enter();
    }
}
