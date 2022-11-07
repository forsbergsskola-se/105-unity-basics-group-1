using System;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float burnTime;
    public int damage;
    private Player player;

    private void Start() {
        Invoke("PutOutFire", burnTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) {
            player = col.GetComponent<Player>();
            InvokeRepeating("DealDamage", 1.0f, 2.0f);
        }
    }

    private void OnTriggerExit(Collider other) {
        CancelInvoke("DealDamage");
    }

    void DealDamage() {
        player.playerInfo.Health -= damage;
    }

    void PutOutFire() {
        Destroy(gameObject);
    }
}
