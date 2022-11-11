using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject prefab;
    private Transform paths;
    public GameObject car;
    void Start()
    {
        paths.GetChild(0);
        
        car.tag = "Player";
    }

    void Update()
    {
        
    }
}
