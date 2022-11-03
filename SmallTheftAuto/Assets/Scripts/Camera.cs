using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject player;
    public float cameraSpeed;
    private Vector3 offset = new Vector3(0f, 10f, 0f);
    void Update() {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * cameraSpeed);
        
        // locked on camera
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
    }
}
