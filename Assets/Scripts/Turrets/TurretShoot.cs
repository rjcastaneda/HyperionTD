using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    private Transform firePoint;
    private Turret _turret;  
    private float nextFire;
    private BulletPoolSystem _bulletPoolSystem;

    [Header("Bullet to Fire")]
    public string bulletType;


    private void Start()
    {
        _turret = gameObject.GetComponent<Turret>();
        _bulletPoolSystem = GameObject.Find("BulletPool").GetComponent<BulletPoolSystem>();
        firePoint = gameObject.transform.Find("Head").transform.Find("FP").GetComponent<Transform>();
    }

    private void Update()
    {
        if(nextFire <= 0f)
        {
            Shoot();
            nextFire = 1f / _turret.fireRate;
        }
        nextFire -= Time.deltaTime;
    }

    private void Shoot()
    {
        if(_turret.targetTrans == null){ return; }

        GameObject bullet = _bulletPoolSystem.GetFromPool(bulletType);
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Bullet>().Seek(_turret.targetTrans);
        bullet.GetComponent<Bullet>().bDamage = _turret.damage;
    }
}
