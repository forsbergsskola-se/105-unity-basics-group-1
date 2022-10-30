using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed;
    public float rotationSpeed;
    void Update()
    {
        var passedTime = Time.deltaTime;
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * passedTime * movementSpeed);
        transform.Rotate(0f, Input.GetAxis("Horizontal") * passedTime * rotationSpeed, 0f);
    }
}
