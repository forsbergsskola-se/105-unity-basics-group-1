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
        //TODO: fix this
        healthText.SetText($"Health: {playerInfo.Health}");
        moneyText.SetText($"Money: {playerInfo.money}");
        scoreText.SetText($"Score: {playerInfo.score}");
        questText.SetText($"{activeQuestInfo.description}");
    }

    public void PlayerDead() {
        bigText.SetText("Wasted");
        bigText.enabled = true;
        Invoke("ReloadScene", 3f);
    }

    void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Scenes/HUD", LoadSceneMode.Additive);
    }
}
