using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("The tower collapsed. You lose.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
