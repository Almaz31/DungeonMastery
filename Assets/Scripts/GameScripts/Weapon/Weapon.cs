using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    private int damage;
    private float bulletSpeed;
    private float reloadTime;
    private int capacity;
    private float attackSpeed;

    public Weapon(int damage, float bulletSpeed, float reloadTime, int capacity, float attackSpeed)
    {
        this.damage = damage;
        this.bulletSpeed = bulletSpeed;
        this.reloadTime = reloadTime;
        this.capacity = capacity;
        this.attackSpeed = attackSpeed;
    }

    public int Damage => damage;
    public float BulletSpeed => bulletSpeed;
    public float ReloadTime => reloadTime;
    public int Capacity => capacity;
    public float AttackSpeed => attackSpeed;
}
