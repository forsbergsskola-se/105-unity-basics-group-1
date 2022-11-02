using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0f, 0f, 0.01f);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0f, 0f, -0.01f);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0f, -0.2f, 0f);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0f, 0.2f, 0f);
        }
    }
}