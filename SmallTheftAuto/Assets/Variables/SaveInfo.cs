using UnityEngine;

[CreateAssetMenu]
public class SaveInfo : ScriptableObject
{
    public bool hasSaved;
    public int health;
    public int money;
    public int score;
    public Vector3 playerPosition;
    
    public void OnSave(Player player, PlayerInfo playerInfo)
    {
        health = playerInfo.Health;
        money = playerInfo.money;
        score = playerInfo.score;
        playerPosition = player.transform.position;
    }
}
