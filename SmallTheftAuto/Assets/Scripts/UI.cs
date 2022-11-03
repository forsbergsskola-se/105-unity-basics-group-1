using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI scoreText;
    
    
    void Update()
    {
        healthText.SetText($"Health: {playerInfo.health}");
        moneyText.SetText($"Money: {playerInfo.money}");
        scoreText.SetText($"Score: {playerInfo.score}");

    }
}
