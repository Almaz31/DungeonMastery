using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InputSubscription InputSub;
    private int slotCount=4;
    private int currentSlot;
    private Weapon[] weapons;
    private Weapon nearWeapon;
    private Weapon currentWeapon;

    void Start()
    {
        weapons = new Weapon[slotCount-1];
        weapons[0] = new Pistol();
    }


    void Update()
    {
        GetInputSlot();
    }
    public void SetNearbyWeapon(Weapon weapon)
    {
        nearWeapon = weapon;
    }
    public void ClearNearbyWeapon()
    {
        nearWeapon = null;
    }
    private void EquipWeapon()
    {
        currentWeapon = nearWeapon;
        weapons[currentSlot] = currentWeapon;
        Debug.Log(currentSlot);
        Debug.Log(currentWeapon);
    }
    private void GetInputSlot()
    {
        if (InputSub.ScrollMouseValue != 0)
        {
            int direction = InputSub.ScrollMouseValue > 0 ? 1 : -1;
            currentSlot = (currentSlot + direction + slotCount) % slotCount;
        }

        if (InputSub.Slot1Input) currentSlot = 0;
        if (InputSub.Slot2Input) currentSlot = 1;
        if (InputSub.Slot3Input) currentSlot = 2;
        if (InputSub.Slot4Input) currentSlot = 3;
    }
}
