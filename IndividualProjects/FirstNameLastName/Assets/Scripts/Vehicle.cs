using UnityEngine;

public class Vehicle : MonoBehaviour {
    public GameObject player;

    public CarMovement carMovement;
    void Update()
    {
        if (EnterCarButtonPressed) {
            if (PlayerIsInCar) player.transform.position = transform.position;
            if (PlayerIsInCar || Vector3.Distance(player.transform.position, transform.position) < 2) {
                TogglePlayerActive();
                ToggleCarActive();
            }
        }
    }

    private bool EnterCarButtonPressed => Input.GetButtonDown("Interact-Vehicle");
    private bool PlayerIsInCar => !player.activeInHierarchy;
    private void TogglePlayerActive() => player.SetActive(PlayerIsInCar);
    private void ToggleCarActive() => carMovement.enabled = PlayerIsInCar; 
}
