using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public float bDamage;
    public Transform seekTarget;
    public float bSpeed = 15f;

    [Header("Aoe Attributes")]
    public bool isAOE;
    public float AOERadius;
    public GameObject explosionEffect;


    private void Update()
    {
        if(seekTarget == null)
        {
            this.gameObject.SetActive(false);
            return;
        }

        Vector3 dir = seekTarget.position - transform.position;
        float distanceFrame = bSpeed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceFrame, Space.World);
    }

    public void Seek(Transform targetTrans)
    {
        seekTarget = targetTrans;
    }

    public void dealAOE()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, AOERadius);
        foreach(Collider collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
            {
                collider.gameObject.GetComponent<Enemy>().TakeDamage(bDamage);
                GameObject expEffect = (GameObject)Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
                Destroy(expEffect, 1.5f);
            }
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(isAOE)
            {
                dealAOE();
                this.gameObject.SetActive(false);
                return;
            }

            collision.gameObject.GetComponent<Enemy>().TakeDamage(bDamage);
            this.gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
