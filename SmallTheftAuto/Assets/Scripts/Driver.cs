
using UnityEngine;

public class Driver : MonoBehaviour
{
    Vehicle [] _vehicles;
    public float lengthAwayFromPlayer;
    
    private void Update()
    {
        if (EnterCarButtonPressed() && IsPlayerCloseEnough())
            _vehicles[0].Enter();
    }
    
    bool EnterCarButtonPressed()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            _vehicles = FindObjectsOfType<Vehicle>();
            return true;
        }

        return false;
    }
    
    bool IsPlayerCloseEnough()
    {
        if(Vector3.Distance(transform.position, _vehicles[0].transform.position) < lengthAwayFromPlayer) 
            return true;
        return false;
    }
}
