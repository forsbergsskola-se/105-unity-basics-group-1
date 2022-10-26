using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        transform.position += transform.right * Random.Range(-.1f, .1f);
    }
}
