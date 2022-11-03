using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float movementSpeed = 15f;
    public float maxSpeed = 5;
    public float rotationSpeed = 5f;
    public Rigidbody _rigidbody;
    void FixedUpdate() {
        if (_rigidbody.velocity.magnitude < maxSpeed)
            _rigidbody.AddRelativeForce(Vector3.forward * (Input.GetAxis("Vertical") * movementSpeed));
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);
    }
}