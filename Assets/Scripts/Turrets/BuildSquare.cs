using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildSquare : MonoBehaviour
{
    private BuildSystem _buildSystem;
    private Renderer thisRend;
    private GameObject selTurret;
    
    [Header("Turret On Square")]
    public GameObject turret;
    public Vector3 squarePosition;

    [Header("Square State Colors")]
    public Color onHover;
    public Color startColor;

    [Header("Constants")]
    private const float TURRET_OFFSET = .1f;

    private void Start()
    {
        thisRend = this.gameObject.GetComponent<Renderer>();
        startColor = thisRend.material.color;
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
        squarePosition = this.gameObject.GetComponent<Renderer>().bounds.center;
    }
    void OnMouseDown()
    {
        int turretCost;
        
        //Prevent clicking when UI over object.
        if (EventSystem.current.IsPointerOverGameObject()) { return; }
        
        if(turret != null)
        {
            _buildSystem.SelectSquare(this);
            return; 
        }

        if (_buildSystem.SelectTurret() == null) { return; }
        selTurret = _buildSystem.SelectTurret();
        turretCost = selTurret.GetComponent<Turret>().cost;

        if(turretCost > _buildSystem.playerMoney){ return; }

        Vector3 offsetPos= new Vector3(transform.position.x,transform.position.y + TURRET_OFFSET, transform.position.z);
        turret = (GameObject)Instantiate(selTurret, offsetPos, transform.rotation);
        _buildSystem.playerMoney -= turretCost;
        
    }

    void OnMouseEnter()
    {
        thisRend.material.color = onHover;
    }

    void OnMouseExit()
    {
        thisRend.material.color = startColor;
    }
}
