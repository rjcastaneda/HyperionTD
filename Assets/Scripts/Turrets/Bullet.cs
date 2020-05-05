﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bDamage;
    public bool isAoe;
    public Transform seekTarget;
    public float bSpeed = 15f;


    private void Update()
    {
        if(seekTarget == null)
        {
            Destroy(this.gameObject);
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
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bDamage);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}