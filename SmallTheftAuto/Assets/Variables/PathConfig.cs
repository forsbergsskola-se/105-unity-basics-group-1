using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PathConfig : ScriptableObject {
    public Transform path;
    public float movementSpeed;

    public Transform GetFirstWaypoint() => path.GetChild(0);
    public float GetMoveSpeed() => movementSpeed;

    public List<Transform> GetWaypoints() {
        List<Transform> list = new List<Transform>();
        foreach (Transform child in path) {
            list.Add(child);
        }
        return list;
    }

}


