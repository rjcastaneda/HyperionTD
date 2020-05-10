using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject turretHead;
    private BuildSystem _buildSystem;
    private GameObject rangeIndicator;

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
    private const float SELL_ADJUSTMENT = .75f;
    private const float UPGRADE_ADJUSTMENT = 1.5f;
    public float DAMAGE_SCALE_FACTOR;
    public float RANGE_SCALE_FACTOR;
    public float FIRERATE_SCALE_FACTOR;


    private void Start()
    {
        rangeCollider = transform.Find("Range").gameObject.GetComponent<SphereCollider>();
        turretHead = this.gameObject.transform.Find("Head").gameObject;
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
        rangeIndicator = _buildSystem.rangeIndicator;
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

    private void UpdateSellCost()
    {
        float newSellCost;
        newSellCost = turretValue * SELL_ADJUSTMENT;
        sellCost = (int)newSellCost;
    }

    private void UpdateUpgradeCost()
    {
        upgradeCost += (int)((float) cost * UPGRADE_ADJUSTMENT);
    }

    private void UpdateStats()
    {
        level++;
        turretValue += upgradeCost;
        damage += (damage * DAMAGE_SCALE_FACTOR);
        fireRate += (fireRate * FIRERATE_SCALE_FACTOR);
        range += (range * RANGE_SCALE_FACTOR);
    }

    public void Upgrade()
    {
        if(level != maxLevel && _buildSystem.playerMoney >= upgradeCost)
        {
            _buildSystem.playerMoney -= upgradeCost;
            UpdateStats();
            UpdateUpgradeCost();
            UpdateSellCost();
            rangeIndicator.transform.localScale = new Vector3(range * 2, rangeIndicator.transform.localScale.y, range * 2);
        }
    }

    public void Sell()
    {
        _buildSystem.playerMoney += sellCost;
        _buildSystem.DeselectSquare();
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
