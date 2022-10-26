using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("The tower collapsed. You lose.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
