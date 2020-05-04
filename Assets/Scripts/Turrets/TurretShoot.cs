using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    private Transform firePoint;
    private Turret _turret;  
    private float nextFire;

    [Header("Bullet to Fire")]
    public GameObject bulletPreFab;

    private void Start()
    {
        _turret = gameObject.GetComponent<Turret>();
        firePoint = gameObject.transform.Find("Head").transform.Find("FP").GetComponent<Transform>();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(_turret.targetTrans == null){ return; }

        if(Time.time > nextFire)
        {
            nextFire = Time.time + _turret.fireRate;
        }

        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().Seek(_turret.targetTrans);
        bullet.GetComponent<Bullet>().bDamage = _turret.damage;

        /*
        RaycastHit hit;
        float ogR = _turret.rangeCollider.radius;
        _turret.rangeCollider.radius = 0f;
        int turretLayer = ~(1 << 10);
        if (Physics.Raycast(firePoint.position, _turret.targetTrans.position, out hit, Mathf.Infinity, turretLayer))
        {
            Debug.DrawLine(firePoint.position, hit.point, Color.red);
            Debug.Log(hit.collider.gameObject.name);
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("Hit Enemy");
                hit.collider.GetComponent<Enemy>().TakeDamage(_turret.damage);
            }
        }
        
        _turret.rangeCollider.radius = ogR;
        */
    }
}
