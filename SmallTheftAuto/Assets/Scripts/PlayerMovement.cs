using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float runSpeed = 0.01f;
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0f, 0f, runSpeed);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0f, 0f, -runSpeed);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0f, -0.2f, 0f);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0f, 0.2f, 0f);
        }
    }
}