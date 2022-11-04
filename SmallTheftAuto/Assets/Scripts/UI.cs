using System;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public ActiveQuestInfo activeQuestInfo;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI questText;
    public TextMeshProUGUI questCompleteText;

    private void Start() {
        activeQuestInfo.description = "";
        questCompleteText.enabled = false;
    }

    void Update()
    {
        healthText.SetText($"Health: {playerInfo.health}");
        moneyText.SetText($"Money: {playerInfo.money}");
        scoreText.SetText($"Score: {playerInfo.score}");
        questText.SetText($"{activeQuestInfo.description}");
    }
}
