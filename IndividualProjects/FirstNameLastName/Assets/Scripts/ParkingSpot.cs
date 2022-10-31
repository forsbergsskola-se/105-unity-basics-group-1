using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    
    public bool hasCar;
    public GameObject carPrefab;

    void Start()
    {
        if (hasCar)
        {
            Instantiate(carPrefab);
            carPrefab.transform.position = transform.position;
        }
    }
}
