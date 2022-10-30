using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public GameObject player;
    public CarMovement carMovement;
    private void Update()
    {
        if (EnterCarButtonPressed())
        {
            if (PlayerIsInCar()) LeaveCar();
            else if(Vector3.Distance(player.transform.position, transform.position) < 3)
            {
                EnterCar();
            }
        }
    }
    bool EnterCarButtonPressed()
    {
        return Input.GetButtonDown("Interact-Vehicle");
    }
    bool PlayerIsInCar()
    {
        return !player.activeInHierarchy;
    }
    void LeaveCar()
    {
        player.transform.position = transform.position;
        player.SetActive(true);
        carMovement.enabled = false;
    }
    void EnterCar()
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }
}
