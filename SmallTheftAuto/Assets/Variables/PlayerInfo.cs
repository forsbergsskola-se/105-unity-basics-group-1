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
