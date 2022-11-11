using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public PathConfig pathConfig;
    private List<Transform> _wayPoints;
    public int _currentWaypoint = 0;
    
    void Start() {
        _wayPoints = pathConfig.GetWaypoints();
        
    }

    void Update() {
        FollowPath();
    }

    private void FollowPath() {
        Vector3 targetPos = _wayPoints[_currentWaypoint].position;
        Vector3 targetDir = targetPos - transform.position;
        float delta = pathConfig.GetMoveSpeed() * Time.deltaTime;   
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, delta, 0f);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, delta);
        transform.rotation = Quaternion.LookRotation(newDirection);
        if (transform.position == targetPos) _currentWaypoint++;
        if (_currentWaypoint == _wayPoints.Count) _currentWaypoint = 0;
    }
}
