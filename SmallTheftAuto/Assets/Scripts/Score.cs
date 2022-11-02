using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.Serialization;


public class Score : MonoBehaviour
{
    public PlayerScore playerScore;

    void Update()

    {
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText($"{playerScore.score}");
    }
}