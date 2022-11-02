using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UI : MonoBehaviour
{
    public PlayerHealth Health;
    void Update()
    
    {TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText ($"{Health.health}");
    }
}
