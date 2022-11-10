using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject _target;
    private readonly Vector3 _offset = new Vector3(0f, 10f, 0f);
    public bool isMinimap;
    
    private Vector3 velocity;
    public float smoothTime;

    private void Start() {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if(_target != null) 
        {
            Vector3 targetPosition = _target.transform.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        if (isMinimap)
        {
            transform.position = _target.transform.position + _offset;
        }
    }

    public void ChangeTarget(GameObject target)
    {
        this._target = target;
    }
}
