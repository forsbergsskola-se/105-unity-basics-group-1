using System;
using UnityEngine;

public class Minimap : MonoBehaviour {

    GameObject _target;
    private readonly Vector3 _offset = new Vector3(0f, 10f, 0f);

    private void Start() {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        transform.position = _target.transform.position + _offset;
    }

    public void ChangeTarget(GameObject newTarget) {
        _target = newTarget;
    }
}