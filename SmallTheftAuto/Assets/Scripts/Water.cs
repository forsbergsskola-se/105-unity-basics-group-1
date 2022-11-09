using UnityEngine;

public class Water : MonoBehaviour
{
    private Player player;
    private Vehicle vehicle;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) {
            player = col.GetComponent<Player>();
            Invoke("DealDamage", 2f);
        }
        else if (col.gameObject.CompareTag("CarE"))
        {
            vehicle = col.GetComponent<Vehicle>();
            vehicle.TakeDamage((int)vehicle.carHealth + 1);
        }
    }

    private void OnTriggerExit(Collider other) {
        CancelInvoke("DealDamage");
    }

    void DealDamage() {
        player.TakeDamage(player.playerInfo.maxHealth);
    }
}
