using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    private int damage;
    private double bulletSpeed;
    private double reloadTime;
    private int capacity;
    private double attackSpeed;

    public Weapon(int damage, double bulletSpeed, double reloadTime, int capacity, double attackSpeed)
    {
        this.damage = damage;
        this.bulletSpeed = bulletSpeed;
        this.reloadTime = reloadTime;
        this.capacity = capacity;
        this.attackSpeed = attackSpeed;
    }

}
