using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IPoolable
{
    [SerializeField] private float bulletLife = 10f;
    private float bulletSpeed;
    private float bulletDamage;
    private Vector2 bulletDirection;
    private Rigidbody rb;
    public event Action<IPoolable> Destroyed;
    public GameObject GameObject => gameObject;
    private float Timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (bulletSpeed > 0)
        {
            rb.velocity = new Vector3(bulletDirection.x,0,bulletDirection.y)*bulletSpeed;
            Timer += Time.deltaTime;
            if (Timer > bulletLife)
            {
                Reset();
                Debug.Log("Reset BulletTimer");
            }
        }
    }
    public void SetParametrsOfBullet(float speed, float damage,Vector2 dir)
    {
        bulletSpeed = speed;
        bulletDamage = damage;
        bulletDirection = dir;
        Timer = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamagatble damagable = other.GetComponent<IDamagatble>();
        if (damagable != null && other.CompareTag("Bullet")==false )
        {
            damagable.GetDamage(bulletDamage);
            Reset();
        }
        else if(!other.CompareTag("Bullet")&& !other.CompareTag("Hero"))
        {
            Reset();
        }
    }
    public void Reset()
    {
        Destroyed?.Invoke(this);
    }
}
