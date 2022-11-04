using UnityEngine;

[CreateAssetMenu]
public class PlayerInfo : ScriptableObject
{
    public int defaultHealth;
    public int defaultMoney;
    public int defaultScore;
    public int health;
    public int money;
    public int score;
    public bool hasQuest;
}
