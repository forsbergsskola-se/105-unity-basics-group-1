using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject player;
    private Vector3 offset = new Vector3(0f, 10f, 0f);
    void LateUpdate() {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * 2.5f);
    }
}
