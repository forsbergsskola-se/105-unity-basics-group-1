using UnityEngine;

public class Vehicle : MonoBehaviour {
    public GameObject player;

    public CarMovement carMovement;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            bool entering = player.activeInHierarchy;
            if (!entering) player.transform.position = transform.position;
            player.SetActive(!entering);
            carMovement.enabled = entering;
        }
    }
}
