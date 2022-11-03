using System;
using UnityEngine;

public class PhoneBox : MonoBehaviour {
    public PlayerInfo playerInfo;

    private void Start() {
        playerInfo.hasQuest = false;
    }

    void OnTriggerEnter(Collider col) {
        if (!col.gameObject.CompareTag("Player")) return;
        if (playerInfo.hasQuest) return;
        Debug.Log("quest get");
        playerInfo.hasQuest = true;
    }
}
