using UnityEngine;

public class Vehicle : MonoBehaviour {
    public GameObject player;

    public CarMovement carMovement;
    void Update()
    {
        if (EnterCarButtonPressed) {
            
            if (PlayerIsInCar) player.transform.position = transform.position;
            ToggleCarActive();
            TogglePlayerActive();
        }
    }

    private bool EnterCarButtonPressed => Input.GetKeyDown(KeyCode.F);
    private bool PlayerIsInCar => !player.activeInHierarchy;
    private void TogglePlayerActive() => player.SetActive(PlayerIsInCar);
    private void ToggleCarActive() => carMovement.enabled = !PlayerIsInCar; 
}
