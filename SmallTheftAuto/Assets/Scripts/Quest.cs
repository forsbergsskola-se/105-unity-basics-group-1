using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public ActiveQuestInfo activeQuestInfo;
    [HideInInspector] public TextMeshProUGUI bigText;
    public PlayerInfo playerInfo;
    private GameObject[] _packages;

    private void Start()
    {
        bigText = GameObject.FindWithTag("BigText").GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter(Collider col)
    { 
        if (col.gameObject.CompareTag("PhoneBox"))
        {
            if (playerInfo.hasQuest) return;
            playerInfo.hasQuest = true;
            _packages = GameObject.FindGameObjectsWithTag("Package");
            TogglePackages(true);
            activeQuestInfo.description = "Pick up the package";
            activeQuestInfo.rewardMoney = 51;
            activeQuestInfo.rewardScore = 35;
        }
        if (playerInfo.hasQuest && col.gameObject.CompareTag("Package"))
        {
            playerInfo.hasQuest = false;
            TogglePackages(false);
            bigText.SetText("Quest Completed");
            bigText.enabled = true;
            playerInfo.money += activeQuestInfo.rewardMoney;
            playerInfo.score += activeQuestInfo.rewardScore;
            activeQuestInfo.description = "";
            activeQuestInfo.rewardMoney = 0;
            activeQuestInfo.rewardScore = 0;
            Invoke("DisableText", 2.0f);
        }
    }
    void TogglePackages(bool state)
    {
        foreach (var package in _packages) 
            package.GetComponent<MeshRenderer>().enabled = state;
    }
    void DisableText() {
        bigText.enabled = false;
    }
}
