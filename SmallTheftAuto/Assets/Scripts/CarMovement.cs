using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float movementSpeed;
    public float maxSpeed;
    public float rotationSpeed;
    public Rigidbody rigidBody;
    void FixedUpdate()
    {
        if (rigidBody.velocity.magnitude < maxSpeed)
        {
            rigidBody.AddRelativeForce(Vector3.right * (Input.GetAxis("Vertical") * movementSpeed));
        }
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);
    }
}
