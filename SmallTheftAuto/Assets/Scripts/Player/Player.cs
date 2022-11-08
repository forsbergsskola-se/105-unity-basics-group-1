using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo playerInfo;

    void Awake()
    {
        playerInfo.ResetDefaults();
    }

    public void TakeDamage(int damage)
    {
        playerInfo.Health -= damage;
    }
       
}
