using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public int playerMoney;

    private GameObject selectedTurret;
    private BuildSquare selectedSquare;
    private GameObject machineGunTurret;
    private GameObject sniperTurret;
    private GameObject flameTurret;
    private TurretInfoPanel _turretInfoPanel;


    private void Start()
    {
        _turretInfoPanel = GameObject.Find("InGameUI").transform.Find("TurretInfoPanel").GetComponent<TurretInfoPanel>();
        machineGunTurret = Resources.Load<GameObject>("Turrets/MGT");
    }

    public void SelectSquare(BuildSquare square)
    {
        if (selectedSquare == square)
        {
            DeselectSquare();
            return;
        }
        
        selectedSquare = square;
        selectedTurret = null;
    }

    public void DeselectSquare()
    {
        selectedSquare = null;
        _turretInfoPanel.NoSelection();
    }

    public GameObject SelectTurret() 
    {
        selectedSquare = null;
        _turretInfoPanel.NoSelection();
        return selectedTurret; 
    }
    public void SelMGT() 
    { 
        selectedTurret = machineGunTurret;
        DeselectSquare();
    }
    public void SelST() 
    { 
        selectedTurret = sniperTurret;
        DeselectSquare();
    }
    public void SelFT() 
    { 
        selectedTurret = flameTurret;
        DeselectSquare();
    }
}
