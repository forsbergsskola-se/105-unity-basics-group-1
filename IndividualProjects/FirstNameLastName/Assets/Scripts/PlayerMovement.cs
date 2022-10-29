using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 150f;
    [SerializeField] float movementSpeed = 6f;
    void FixedUpdate() {
        float passedTime = Time.deltaTime;
        
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * passedTime * movementSpeed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * passedTime * rotationSpeed, 0f);
    }
}
