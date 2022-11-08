using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class PlayerInfo : ScriptableObject
{
    public int defaultHealth;
    public int defaultMoney;
    public int defaultScore;
    
    public UnityEvent<int> healthChange;
    public int Health {
        get => _health;
        set {
            _health = value;
            healthChange?.Invoke(value);
            if (_health < 1) {
                _health = 0;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
                GameObject.FindWithTag("UI").GetComponent<UI>().PlayerDead();
            }
        }
    }
    
    public int money;
    public int score;
    public bool hasQuest;
    int _health;

    public void ResetDefaults() {
        _health = defaultHealth;
        money = defaultMoney;
        score = defaultScore;
        hasQuest = false;
    }
}
