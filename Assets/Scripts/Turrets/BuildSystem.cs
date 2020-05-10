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
    private GameObject missileTurret;
    private TurretInfoPanel _turretInfoPanel;

    public GameObject selectionMarker;
    public GameObject rangeIndicator;

    [Header("Constants")]
    private const float MARKER_OFFSET = 1.5f;
    private const float RANGE_OFFSET = .1f;

    private void Start()
    {
        _turretInfoPanel = GameObject.Find("InGameUI").transform.Find("TurretInfoPanel").GetComponent<TurretInfoPanel>();
        machineGunTurret = Resources.Load<GameObject>("Turrets/MGT");
        sniperTurret = Resources.Load<GameObject>("Turrets/SniperTurret");
        missileTurret = Resources.Load<GameObject>("Turrets/MissileTurret");
    }

    private void Update()
    {
        //Right-Clicking will deselect and stop building
        if(Input.GetMouseButtonDown(1))
        {
            DeselectSquare();
            selectedTurret = null;
        }
       
    }

    public void SelectSquare(BuildSquare square)
    {
        float rangeScale = square.turret.GetComponent<Turret>().range * 2;

        if (selectedSquare == square)
        {
            DeselectSquare();
            return;
        }

        selectionMarker.SetActive(true);
        rangeIndicator.SetActive(true);
        selectedSquare = square;
        selectedTurret = null;
        Vector3 markerPos = new Vector3(square.squarePosition.x, square.squarePosition.y + MARKER_OFFSET, square.squarePosition.z);
        Vector3 rangePos = new Vector3(square.squarePosition.x, square.squarePosition.y + RANGE_OFFSET, square.squarePosition.z);
        rangeIndicator.transform.localScale = new Vector3(rangeScale, rangeIndicator.transform.localScale.y, rangeScale);
        rangeIndicator.transform.position = rangePos;
        selectionMarker.transform.position = markerPos;
        _turretInfoPanel.setTarget(square.turret.GetComponent<Turret>());
        _turretInfoPanel.OnSelection();
    }

    public void DeselectSquare()
    {
        selectionMarker.SetActive(false);
        rangeIndicator.SetActive(false);
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

    public void SelMT() 
    { 
        selectedTurret = missileTurret;
        DeselectSquare();
    }
}
