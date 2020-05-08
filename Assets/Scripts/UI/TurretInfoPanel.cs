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
    private BuildSquare targetSquare;
    private Turret targetTurret;

    //TurretInfoPanel UI Elements
    private Button upgradeButton;
    private Button sellButton;
    private TextMeshProUGUI upgradeCost;
    private TextMeshProUGUI sellCost;

    public void Start()
    {
        upgradeButton = transform.Find("UpgradeButton").GetComponent<Button>();
        sellButton = transform.Find("SellButton").GetComponent<Button>();
        upgradeCost = transform.Find("UpgradeButton").transform.Find("Cost (TMP)").GetComponent<TextMeshProUGUI>();
        sellCost = transform.Find("SellButton").transform.Find("Cost (TMP)").GetComponent<TextMeshProUGUI>();
    }

    public void setTarget (BuildSquare square)
    {
        targetSquare = square;
        targetTurret = targetSquare.turretInfo;
    }

    public void NoSelection()
    {
        targetSqaure = null;
        targetTurret = null;
        upgradeButton.interactable = false;
        sellButton.interactable = false;
        upgradeCost.text = "No Selection";
        sellCost.text = "No Selection";
    }
}
