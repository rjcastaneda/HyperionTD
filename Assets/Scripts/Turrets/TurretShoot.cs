using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    private Transform firePoint;
    private Turret _turret;  
    private float nextFire;


    private void Start()
    {
        _turret = gameObject.GetComponent<Turret>();
        firePoint = gameObject.transform.Find("FP").transform;
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


        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, _turret.targetTrans.position, out hit, _turret.range))
        {
            Debug.DrawRay(firePoint.position, hit.point, Color.red);
            if (hit.transform.CompareTag("Enemy"))
            {
                Debug.Log("Hit Enemy");
                hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(_turret.damage);
            }
        }


    }
}
