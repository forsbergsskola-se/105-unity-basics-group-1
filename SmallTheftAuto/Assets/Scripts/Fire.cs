using UnityEngine;

public class Fire : MonoBehaviour
{
    public float burnTime;
    public int damage;
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
