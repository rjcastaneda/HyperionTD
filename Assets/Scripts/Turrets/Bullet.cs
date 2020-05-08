using System.Collections;
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
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bDamage);
            this.gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
