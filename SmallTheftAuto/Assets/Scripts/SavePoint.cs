using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public SaveInfo saveInfo;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (!_player.playerInfo.hasQuest)
        {
            saveInfo.OnSave(_player, _player.playerInfo);
            saveInfo.hasSaved = true;
            Debug.Log("saved");
        }
    }
    
}
