using UnityEngine;

public class Quest : MonoBehaviour 
{
    public PlayerInfo playerInfo;
    private void Start() {
        playerInfo.hasQuest = false;
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("PhoneBox"))
        {
            if (playerInfo.hasQuest) return;
            playerInfo.hasQuest = true;
            Debug.Log("Pick up the package");
        }
        
        
        
        
    }
}
