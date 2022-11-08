using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed;
    public float maxSpeed;
    public float rotationSpeed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        if (_rigidbody.velocity.magnitude < maxSpeed)
            _rigidbody.transform.Translate(Vector3.forward * (Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime));
        transform.Rotate(Vector3.up * (Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime));
    }
}