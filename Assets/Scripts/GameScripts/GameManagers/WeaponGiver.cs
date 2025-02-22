using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiver : MonoBehaviour
{

    public Weapon GetWeapon()
    {
        return new Pistol();
    }
}
