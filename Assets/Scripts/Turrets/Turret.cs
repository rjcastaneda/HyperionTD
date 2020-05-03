using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret Attributes")]
    public string type;
    public int cost;
    public float range;
    public float fireRate;

    [Header("Target")]
    public GameObject target;

    private GameObject[] enemiesInRange;
    private GameObject turretHead;

    private void Awake()
    {
        turretHead = this.gameObject.transform.Find("Head").gameObject;
        InvokeRepeating("FindTarget", 0f, .1f);
    }

    private void Update()
    {
        if(target == null){ return; }
        rotateTurret();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    private void rotateTurret()
    {
        //Rotate towards target
        Vector3 direction = target.transform.position - transform.position;
        Quaternion aimRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = aimRotation.eulerAngles;
        turretHead.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void FindTarget()
    {
        float distanceToT;
        float distanceThreshold = Mathf.Infinity;

        enemiesInRange = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject _enemy in enemiesInRange)
        {
            distanceToT = Vector3.Distance(transform.position, _enemy.transform.position);
            if (distanceToT < distanceThreshold && distanceToT <= range)
            {
                distanceThreshold = distanceToT;
                target = _enemy;
            }
            else
            {
                target = null;
            }
        } 
    }
}
