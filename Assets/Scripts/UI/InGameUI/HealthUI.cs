using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public static HealthUI instance;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        if(instance == null)instance = this;
    }

    public void UpdateHealth(int health)
    {
        healthText.text = health.ToString();
    }
}
