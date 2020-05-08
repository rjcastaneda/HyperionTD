using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject turretHead;
    private BuildSystem _buildSystem;
    private Player _player;

    [Header("Turret Attributes")]
    public int level;
    public int maxLevel;
    public int turretValue;
    public int cost;
    public int upgradeCost;
    public int sellCost;
    public float damage;
    public float range;
    public float fireRate;
    

    [Header("Target")]
    public GameObject target;
    public Transform targetTrans;
    public List<GameObject> enemiesInRange;
    public SphereCollider rangeCollider;

    [Header("Constants")]
    private const float SELL_ADJUSTMENT = .75F;
    private const int UPGRADE_ADJUSTMENT = 2;
    public float DAMAGE_SCALE_FACTOR;
    public float RANGE_SCALE_FACTOR;
    public float FIRERATE_SCALE_FACTOR;


    private void Start()
    {
        rangeCollider = transform.Find("Range").gameObject.GetComponent<SphereCollider>();
        turretHead = this.gameObject.transform.Find("Head").gameObject;
        _player = GameObject.Find("Player").GetComponent<Player>();
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
        InvokeRepeating("Targetting", 0, .01f);

        //Set Defaults
        turretValue = cost;
        upgradeCost = cost;
        UpdateSellCost();
    }

    private void Update()
    {
        rangeCollider.radius = range;
        if(targetTrans == null)
        {
            enemiesInRange.Remove(target);
            return; 
        }

        RotateTurret();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void UpdateSellCost()
    {
        float newSellCost;
        newSellCost = turretValue * SELL_ADJUSTMENT;
        sellCost = (int)newSellCost;
    }

    public void UpdateUpgradeCost()
    {
        upgradeCost += cost * UPGRADE_ADJUSTMENT;
    }

    public void Upgrade()
    {
        if(level != maxLevel && _buildSystem.playerMoney >= upgradeCost)
        {
            _buildSystem.playerMoney -= upgradeCost;
            level++;
            turretValue += upgradeCost;
            damage += (damage * DAMAGE_SCALE_FACTOR);
            fireRate += (fireRate * FIRERATE_SCALE_FACTOR);
            range += (range * RANGE_SCALE_FACTOR);
            UpdateUpgradeCost();
            UpdateSellCost();
        }
    }

    public void Sell()
    {
        _buildSystem.playerMoney += sellCost;
        Destroy(this.gameObject);
    }

    private void RotateTurret()
    {
        //Rotate towards target
        Vector3 direction = targetTrans.position - transform.position;
        Quaternion aimRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = aimRotation.eulerAngles;
        turretHead.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void Targetting()
    {
        byte FIRST_ENEMY = 0;

        if(enemiesInRange.Count == 0)
        { 
            return; 
        }

        //Turret will target at the enemy in front;
        target = enemiesInRange[FIRST_ENEMY];

        if(target != null)
        {
            targetTrans = target.transform;
        }  
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(col.gameObject);
        }

    }

    void OnCollisionExit(Collision col)
    {
        if (ReferenceEquals(target, col.gameObject))
        {
            target = null;
            targetTrans = null;
        }
        enemiesInRange.Remove(col.gameObject);
    }
}
