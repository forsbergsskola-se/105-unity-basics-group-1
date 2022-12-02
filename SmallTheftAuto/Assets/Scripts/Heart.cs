using System;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int healPoints;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (_player.playerInfo.Health != _player.playerInfo.maxHealth)
            {
                _player.playerInfo.Health += healPoints;
                Destroy(gameObject);
            }
        }
    }

}
