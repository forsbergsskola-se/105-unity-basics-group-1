using UnityEngine;

[CreateAssetMenu]
public class PlayerInfo : ScriptableObject
{
    public int defaultHealth;
    public int defaultMoney;
    public int defaultScore;
    public SaveInfo saveInfo;
    private Player _player;
    public int Health {
        get => health;
        set {
            health = value;
            if (health < 1) {
                health = 0;
                GameObject player = GameObject.FindWithTag("Player");
                player.GetComponent<PlayerMovement>().enabled = false;
                // player.GetComponent<Shoot>().enabled = false;
                GameObject.FindWithTag("UI").GetComponent<UI>().PlayerDead();
            }
        }
    }
    
    public int money;
    public int score;
    public bool hasQuest;
    int health;

    public void SetPlayerInfo(Player player) {
        if (!saveInfo.hasSaved)
        {
            health = defaultHealth;
            money = defaultMoney;
            score = defaultScore;
            hasQuest = false;
        }
        else
        {
            health = saveInfo.health;
            money = saveInfo.money;
            score = saveInfo.score;
            player.transform.position = saveInfo.playerPosition;
        }
    }
}
