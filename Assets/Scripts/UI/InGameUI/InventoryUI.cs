using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    [SerializeField] private GameObject Slot1;
    [SerializeField] private GameObject Slot2;
    [SerializeField] private GameObject Slot3;
    [SerializeField] private GameObject Slot4;
    [SerializeField] private Vector2 ActiveSlotSize;
    private Vector2 SlotSize;
    private int currentSlot;

    void Start()
    {
        if (Instance == null)Instance = this;
        SlotSize = new Vector2(50, 50);
        SetActiveSlot(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetActiveSlot(int slotId)
    {
        ResetSizeSlots();
        switch (slotId)
        {
            case 0:
                Slot1.GetComponent<RectTransform>().sizeDelta = ActiveSlotSize;
                return;
            case 1:
                Slot2.GetComponent<RectTransform>().sizeDelta = ActiveSlotSize;
                return;
            case 2:
                Slot3.GetComponent<RectTransform>().sizeDelta = ActiveSlotSize;
                return;
            case 3:
                Slot4.GetComponent<RectTransform>().sizeDelta = ActiveSlotSize;
                return;
        }
    }
    void ResetSizeSlots()
    {
        Slot1.GetComponent<RectTransform>().sizeDelta = SlotSize;
        Slot2.GetComponent<RectTransform>().sizeDelta = SlotSize;
        Slot3.GetComponent<RectTransform>().sizeDelta = SlotSize;
        Slot4.GetComponent<RectTransform>().sizeDelta = SlotSize;
    }
}
