using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.Serialization;


public class Money : MonoBehaviour
{
    public PlayerMoney playerMoney;

    void Update()

    {
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText($"{playerMoney.money}");
    }
}
