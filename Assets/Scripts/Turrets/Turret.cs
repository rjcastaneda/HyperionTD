using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret Attributes")]
    public string type;
    public int cost;
    public float damage;
    public float range;
    public float fireRate;
    public float distanceToT;

    [Header("Target")]
    public GameObject target;
    public Transform targetTrans;

    public List<GameObject> enemiesInRange;
    private GameObject turretHead;
    public SphereCollider rangeCollider;

    private void Start()
    {
        rangeCollider = transform.Find("Range").gameObject.GetComponent<SphereCollider>();
        turretHead = this.gameObject.transform.Find("Head").gameObject;
        InvokeRepeating("Targetting", 0, .01f);
    }

    private void Update()
    {
        rangeCollider.radius = range;
        if(targetTrans == null){
            enemiesInRange.Remove(target);
            return; }
        RotateTurret();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void RotateTurret()
    {
        //Rotate towards target
        Vector3 direction = targetTrans.position - transform.position;
        Quaternion aimRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = aimRotation.eulerAngles;
        turretHead.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }


    //Turret will target at the enemy in front;
    private void Targetting()
    {
        byte FIRST_ENEMY = 0;
        if(enemiesInRange.Count == 0){ return; }
        target = enemiesInRange[FIRST_ENEMY];
        targetTrans = target.transform;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Trigger Detected");
        if (col.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(col.gameObject);
        }

    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("Trigger Exit Detected");
        if (ReferenceEquals(target, col.gameObject))
        {
            target = null;
            targetTrans = null;
        }
        enemiesInRange.Remove(col.gameObject);
    }
}
