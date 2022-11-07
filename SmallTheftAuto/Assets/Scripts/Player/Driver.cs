using UnityEngine;

public class Driver : MonoBehaviour
{
    private Vehicle _vehicle;
    private Vehicle [] _vehicles;
    public float lengthAwayFromPlayer;

    private void Update()
    {
        if (EnterCarButtonPressed())
        {
            float closestCar = 100f;
            _vehicles = FindObjectsOfType<Vehicle>();
            foreach (var t in _vehicles)
            {
                float nextCar = Vector3.Distance(t.transform.position, transform.position);
                if(nextCar < closestCar)
                {
                    _vehicle = t;
                    closestCar = nextCar;
                }
            }
            if(IsPlayerCloseEnough())
            {
                _vehicle.isItMyCar = true;
                _vehicle.Enter();
            }
        }
    }
    
    bool EnterCarButtonPressed() => Input.GetButtonDown("Interact-Vehicle");
    
    bool IsPlayerCloseEnough()
    {
        return Vector3.Distance(transform.position, _vehicle.transform.position) < lengthAwayFromPlayer;
    }
}
