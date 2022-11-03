using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float movementSpeed;
    public float maxSpeed;
    public float currSpeed;
    public float rotationSpeed;
    public Rigidbody rigidBody;
    void FixedUpdate()
    {
        currSpeed = rigidBody.velocity.magnitude;
        
        if (currSpeed < maxSpeed)
        {
             rigidBody.AddRelativeForce(Vector3.right * (Input.GetAxis("Vertical") * movementSpeed));
        }
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);

        //Todo: fix so it doesn't keep decreasing after movementspeed < 0
        if (Input.GetKey(KeyCode.Space))
            rigidBody.AddRelativeForce(-(Vector3.right * (Input.GetAxis("Vertical") * movementSpeed)));
    }
}
