using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public ActiveQuestInfo activeQuestInfo;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI questText;
    public TextMeshProUGUI bigText;

    private void Start() {
        activeQuestInfo.description = "";
        bigText.enabled = false;
    }

    void Update()
    {
        healthText.SetText($"Health: {playerInfo.Health}");
        moneyText.SetText($"Money: {playerInfo.money}");
        scoreText.SetText($"Score: {playerInfo.score}");
        questText.SetText($"{activeQuestInfo.description}");
    }

    public void PlayerDead() {
        bigText.SetText("Wasted");
        bigText.enabled = true;
        // load scene here later
    }
}
