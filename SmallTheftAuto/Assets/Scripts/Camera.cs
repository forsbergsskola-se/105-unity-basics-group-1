using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject target;
    public float cameraSpeed;
    private Vector3 offset = new Vector3(0f, 10f, 0f);
    private Vector3 velocity;
    void Update() {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + offset, ref velocity, cameraSpeed);
        
        // locked on camera
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
    }

    public void ChangeTarget(GameObject target)
    {
        this.target = target;
    }
}
