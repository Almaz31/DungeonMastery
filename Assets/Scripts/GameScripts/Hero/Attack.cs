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
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float smoothValue;
    private Weapon currentWeapon;
    private bool Reloading;
    private bool isShooting = false;
    private int currentCapicity;
    private float ReloadTimer;
    private float ReloadWeapon;
    private float bulletSpeed;
    private int bulletDamage;
    private float r;


    void Start()
    {
        currentWeapon = new Pistol();
        currentCapicity = currentWeapon.Capacity;
        ShowBullets.instance.UpdatebulletCounts(currentCapicity);
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
            ShowBullets.instance.StartReloading();
            ReloadTimer += Time.deltaTime;
            if (ReloadTimer >= ReloadWeapon)
            {
                Reloading= false;
                currentCapicity= currentWeapon.Capacity;
                ShowBullets.instance.UpdatebulletCounts(currentCapicity);
                ShowBullets.instance.StopReloading();
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

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg * -1;

        float HeroAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref r, smoothValue);
        transform.rotation = Quaternion.Euler(0, HeroAngle, 0);

        Bullet bullet = PoolObject.Instance.GetObject(bulletPrefab);
        Vector3 worldPosition = bulletSpawnTransform.parent.TransformPoint(bulletSpawnTransform.localPosition);
        bullet.transform.position = worldPosition;
        
        bullet.transform.rotation = Quaternion.Euler(0, angle, 90f);

        bullet.SetParametrsOfBullet(bulletSpeed, bulletDamage, dir);
        currentCapicity -= 1;
        ShowBullets.instance.UpdatebulletCounts(currentCapicity);
        yield return new WaitForSeconds(1f / attSpeed);
        isShooting = false;

    }
    private Vector2 GetAttackDir()
    {
       
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, layerMask))
        {
            Vector3 direction = (hitInfo.point - transform.position).normalized;
            return new Vector2(direction.x, direction.z);
        }
        return Vector2.zero;
    }
    

}
