using UnityEngine;

public class Quest : MonoBehaviour 
{
    public PlayerInfo playerInfo;
    public ActiveQuestInfo activeQuestInfo;
    private GameObject[] packages;
    private void Start() {
        playerInfo.hasQuest = false;
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("PhoneBox"))
        {
            Debug.Log("has quest");
            if (playerInfo.hasQuest) return;
            playerInfo.hasQuest = true;
            packages = GameObject.FindGameObjectsWithTag("Package");
            TogglePackages(true);
            activeQuestInfo.description = "Pick up the package";
        }
        if (playerInfo.hasQuest && col.gameObject.CompareTag("Package"))
        {
            playerInfo.hasQuest = false;
            activeQuestInfo.description = "";
            TogglePackages(false);
            Debug.Log("Quest complete.");
        }
    }
    void TogglePackages(bool state)
    {
        foreach (var package in packages) 
            package.GetComponent<MeshRenderer>().enabled = state;
    }
}
