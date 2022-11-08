using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo playerInfo;

    void Awake()
    {
        Debug.Log("waking up");
        playerInfo.SetPlayerInfo(this);
    }

    public void TakeDamage(int damage)
    {
        playerInfo.Health -= damage;
    }
       
}
