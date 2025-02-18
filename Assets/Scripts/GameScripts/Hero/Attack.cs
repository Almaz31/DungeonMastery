using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] InputSubscription InputSub;
    [SerializeField] Transform bulletSpawnTransform;
    [SerializeField]Bullet bulletPrefab;
    [SerializeField] bool isTest;
    [SerializeField] private float attackSpeedTest = 1f;
    [SerializeField] private float reloadingTest = 3f;
    [SerializeField] private float bulletSpeedTest = 3f;
    [SerializeField] private int bulletDamageTest = 10;
    private Weapon currentWeapon;
    private bool Reloading;
    private bool isShooting = false;
    private int currentCapicity;
    private float ReloadTimer;
    private float ReloadWeapon;
    private float bulletSpeed;
    private int bulletDamage;


    void Start()
    {
        currentWeapon = new Pistol();
        currentCapicity = currentWeapon.Capacity;
        ReloadWeapon = isTest ? reloadingTest : currentWeapon.ReloadTime;
    }


    void Update()
    {
        if (InputSub.AttackInput && !Reloading&&!isShooting)
        {
            isShooting = true;
            Shoot();
        }
        if (Reloading)
        {
            ReloadTimer += Time.deltaTime;
            if (ReloadTimer >= ReloadWeapon)
            {
                Reloading= false;
                currentCapicity= currentWeapon.Capacity;
                ReloadTimer = 0;
            }
        }

    }
    void Shoot()
    {
        if (currentCapicity > 0)
        {
            StartCoroutine(ShootCoroutine());

        }
        else
        {
            isShooting = false;
            StopAllCoroutines();
            Reloading = true;
        }

    }
    private IEnumerator ShootCoroutine()
    {
        isShooting = true;
        float attSpeed = isTest ? attackSpeedTest : currentWeapon.AttackSpeed;
        bulletSpeed = isTest ? bulletSpeedTest : currentWeapon.BulletSpeed;
        bulletDamage = isTest ? bulletDamageTest : currentWeapon.Damage;

        Vector2 dir = GetAttackDir();
        
        Bullet bullet = PoolObject.Instance.GetObject(bulletPrefab);
        Vector3 worldPosition = bulletSpawnTransform.parent.TransformPoint(bulletSpawnTransform.localPosition);
        bullet.transform.position = worldPosition;
        bullet.transform.rotation = transform.rotation;
        bullet.SetParametrsOfBullet(bulletSpeed, bulletDamage, dir);
        currentCapicity -= 1;
        yield return new WaitForSeconds(1f / attSpeed);
        isShooting = false;
    }
    private Vector2 GetAttackDir()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector3 attackDirection = (mouseWorldPos - transform.position).normalized;
        Vector2 attackDirection2D = new Vector2(attackDirection.x, attackDirection.y);
        return attackDirection2D;
    }
    

}
