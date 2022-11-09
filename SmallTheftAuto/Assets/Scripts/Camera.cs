using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject target;
    public float cameraSpeed;
    private Vector3 offset = new Vector3(0f, 10f, 0f);

    //testing
    public Transform target2;
    public Vector3 offset2 = new Vector3(0, 4, 0);
    private Vector3 velocity;
    public float smoothTime;

    void Update() {
        //transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * cameraSpeed);

        // locked on camera
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
        
        //testing new camera dampen
        if(target != null) 
        {
            Vector3 targetPosition = target.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    public void ChangeTarget(GameObject target)
    {
        this.target = target;
    }
}
