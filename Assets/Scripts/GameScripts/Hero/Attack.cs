using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] InputSubscription InputSub;
    [SerializeField] Transform bulletSpawnTransform;
    [SerializeField]Bullet bulletPrefab;
    private Weapon currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = new Pistol();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputSub.AttackInput)
        {
            Debug.Log("Attack");
            Vector2 dir = GetAttackDir();
            Bullet bullet = PoolObject.Instance.GetObject(bulletPrefab);
            bullet.transform.position = bulletSpawnTransform.position;
            bullet.SetParametrsOfBullet(currentWeapon.BulletSpeed, currentWeapon.Damage, dir);
        }
    }
    Vector2 GetAttackDir()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector3 attackDirection = (mouseWorldPos - transform.position).normalized;
        Vector2 attackDirection2D = new Vector2(attackDirection.x, attackDirection.y);
        return attackDirection2D;
    }
}
