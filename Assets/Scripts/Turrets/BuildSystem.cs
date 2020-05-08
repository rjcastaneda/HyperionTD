using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public int playerMoney;

    private BuildSquare selectedSquare;
    private GameObject selectedTurret;
    private GameObject machineGunTurret;
    private GameObject sniperTurret;
    private GameObject flameTurret;
    public GameObject SelectionMarker;
    private TurretInfoPanel _turretInfoPanel;

    private void Start()
    {
        _turretInfoPanel = GameObject.Find("InGameUI").transform.Find("TurretInfoPanel").GetComponent<TurretInfoPanel>();
        machineGunTurret = Resources.Load<GameObject>("Turrets/MGT");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1)){ DeselectSquare(); }
    }

    public void SelectSquare(BuildSquare square)
    {
        if (selectedSquare == square)
        {
            DeselectSquare();
            return;
        }

        //SelectionMarker.SetActive(true);
        selectedSquare = square;
        selectedTurret = null;

        _turretInfoPanel.setTarget(square.turret.GetComponent<Turret>());
        _turretInfoPanel.OnSelection();
    }

    public void DeselectSquare()
    {
        //SelectionMarker.SetActive(false);
        selectedSquare = null;
        _turretInfoPanel.NoSelection();
    }

    public GameObject SelectTurret() 
    {
        selectedSquare = null;
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
