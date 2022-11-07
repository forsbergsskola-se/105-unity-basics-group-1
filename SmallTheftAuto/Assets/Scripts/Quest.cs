using System;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public ActiveQuestInfo activeQuestInfo;
    public TextMeshProUGUI questCompletedText;
    public PlayerInfo playerInfo;
    private GameObject[] _packages;

    void OnTriggerEnter(Collider col)
    { 
        if (col.gameObject.CompareTag("PhoneBox"))
        {
            if (playerInfo.hasQuest) return;
            playerInfo.hasQuest = true;
            _packages = GameObject.FindGameObjectsWithTag("Package");
            TogglePackages(true);
            activeQuestInfo.description = "Pick up the package";
        }
        if (playerInfo.hasQuest && col.gameObject.CompareTag("Package"))
        {
            playerInfo.hasQuest = false;
            activeQuestInfo.description = "";
            TogglePackages(false);
            questCompletedText.enabled = true;
            Invoke("DisableText", 2.0f);
        }
    }
    void TogglePackages(bool state)
    {
        foreach (var package in _packages) 
            package.GetComponent<MeshRenderer>().enabled = state;
    }
    void DisableText() {
        questCompletedText.enabled = false;
    }
}
