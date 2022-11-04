using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool _hasQuest;
    public ActiveQuestInfo activeQuestInfo;
    public TextMeshProUGUI questCompletedText;
    private GameObject[] _packages;
    void OnTriggerEnter(Collider col)
    {
        _hasQuest = GetComponent<Player>().playerInfo.hasQuest;
        if (col.gameObject.CompareTag("PhoneBox"))
        {
            if (_hasQuest) return;
            _hasQuest = true;
            _packages = GameObject.FindGameObjectsWithTag("Package");
            TogglePackages(true);
            activeQuestInfo.description = "Pick up the package";
        }
        if (_hasQuest && col.gameObject.CompareTag("Package"))
        {
            _hasQuest = false;
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
