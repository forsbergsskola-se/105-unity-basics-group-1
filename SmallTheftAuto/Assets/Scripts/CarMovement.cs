
using Unity.VisualScripting;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float movementSpeed;
    public float maxSpeed;
    public float currSpeed;
    public float rotationSpeed;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //to see the car speed
        currSpeed = _rigidBody.velocity.magnitude;
        
        if (currSpeed < maxSpeed)
        {
             _rigidBody.AddRelativeForce(Vector3.right * (Input.GetAxis("Vertical") * movementSpeed));
        }
        if(_rigidBody.velocity != Vector3.zero) 
            transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);
            
            //Todo: fix so it doesn't keep decreasing after movementSpeed < 0
        if (Input.GetKey(KeyCode.Space))
            if(_rigidBody.velocity != Vector3.zero) // Kinda works
                _rigidBody.AddRelativeForce(-(Vector3.right * (Input.GetAxis("Vertical") * movementSpeed)));
    }
}
