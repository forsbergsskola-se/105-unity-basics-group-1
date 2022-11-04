using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public PlayerInfo playerInfo;

    void Awake()
    {
        playerInfo.health = playerInfo.defaultHealth;
    }

    public void TakeDamage(int damage)
    {
        playerInfo.health -= damage;
    }
    
}
