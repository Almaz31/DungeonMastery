using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowBullets : MonoBehaviour
{
    public static ShowBullets instance;
    [SerializeField] private TextMeshProUGUI bulletCount;

    private void Start()
    {
        if(instance == null)instance = this;
    }
    public void UpdatebulletCounts(int count)
    {
        bulletCount.text = count.ToString();
    }
    public void StartReloading()
    {
        Debug.Log("Start reloading..");
    }
    public void StopReloading()
    {
        Debug.Log("Stop reloading..");
    }
}
