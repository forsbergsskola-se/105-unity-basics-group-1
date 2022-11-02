using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class Health : MonoBehaviour
{
     public PlayerHealth playerHealth;
    void Update()
    
    {TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText ($"{playerHealth.health}");
    }
}
