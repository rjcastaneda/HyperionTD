/*
 *  Script Name: TurrentPanel.cs
 *  Script Description:
 *  
 *     Attached to the TurretInfoPanel Game Object.
 *     Handles operations regarding selecting a turret, returning turret info to the UI, and upgrading and selling.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretInfoPanel : MonoBehaviour
{
    private Turret targetTurret;

    [Header("TurretInfoPanel UI Elements")]
    private Button upgradeButton;
    private Button sellButton;
    public TextMeshProUGUI turretLevel;
    public TextMeshProUGUI turretDamage;
    public TextMeshProUGUI turretFireRate;
    public TextMeshProUGUI turretRange;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;

    private void Start()
    {
        upgradeButton = this.transform.Find("UpgradeButton").GetComponent<Button>();
        sellButton = this.transform.Find("SellButton").GetComponent<Button>();
        NoSelection();
    }

    public void Update()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if(targetTurret == null){ return; }
        if(targetTurret.level >= targetTurret.maxLevel)
        {
            upgradeCost.text = "MAX UPGRADE";
            turretLevel.text = "MAX";
        }
        else
        {
            turretLevel.text = targetTurret.level.ToString("F2");
            upgradeCost.text = "$" + targetTurret.upgradeCost.ToString();
        }
        turretDamage.text = targetTurret.damage.ToString("F2");
        turretRange.text = targetTurret.range.ToString("F2");
        turretFireRate.text = targetTurret.fireRate.ToString("F2");
        
        sellCost.text = "$" + targetTurret.sellCost.ToString();
    }

     public void UpgradeButton()
     {
        targetTurret.Upgrade();
     }

    public void SellButton()
    {
        targetTurret.Sell();
    }

    public void setTarget (Turret _turret)
    {
        targetTurret = _turret;
    }

    public void OnSelection()
    {
        upgradeButton.interactable = true;
        sellButton.interactable = true;
        upgradeCost.text = "$" + targetTurret.upgradeCost.ToString();
        sellCost.text = "$" + targetTurret.sellCost.ToString();
    }

    //Function for when Deselecting occurs
    public void NoSelection()
    {
        targetTurret = null;
        upgradeButton.interactable = false;
        sellButton.interactable = false;
        upgradeCost.text = "No Selection";
        sellCost.text = "No Selection";
        turretLevel.text = "0";
        turretDamage.text = "0";
        turretRange.text = "0";
        turretFireRate.text = "0";
    }
}
