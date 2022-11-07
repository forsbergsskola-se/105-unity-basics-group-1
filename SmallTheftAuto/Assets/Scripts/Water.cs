using UnityEngine;

public class Water : MonoBehaviour
{
    private Player player;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) {
            player = col.GetComponent<Player>();
            Invoke("DealDamage", 2f);
        }
    }

    private void OnTriggerExit(Collider other) {
        CancelInvoke("DealDamage");
    }

    void DealDamage() {
        player.playerInfo.Health = 0;
    }
}
