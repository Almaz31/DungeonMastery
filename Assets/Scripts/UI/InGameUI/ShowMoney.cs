using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMoney : MonoBehaviour
{
    public static ShowMoney Instance;
    [SerializeField] private TextMeshProUGUI moneyText;
    private void Start()
    {
        if(Instance == null)Instance = this;
    }
    private void UpdateMoney(int count)
    {
        moneyText.text = count.ToString();
    }
}
