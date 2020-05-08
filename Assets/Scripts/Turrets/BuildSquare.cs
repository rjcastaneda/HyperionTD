using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildSquare : MonoBehaviour
{
    private BuildSystem _buildSystem;
    private Renderer thisRend;
    private GameObject turret;
    private GameObject selTurret;

    [Header("Turret on Square")]
    public Turret turretInfo;

    [Header("Square State Colors")]
    public Color onHover;
    public Color startColor;

    private void Start()
    {
        thisRend = this.gameObject.GetComponent<Renderer>();
        startColor = thisRend.material.color;
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
    }

    void OnMouseDown()
    {
        int turretCost;
        float offset = .1f;
        

        //Prevent clicking when UI over object.
        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            Debug.Log("Clicking on UI");
            return; 
        }

        if(turret != null)
        {
            _buildSystem.SelectSquare(this);
            return; 
        }

        selTurret = _buildSystem.SelectTurret();
        turretCost = selTurret.GetComponent<Turret>().cost;

        if(turretCost > _buildSystem.playerMoney)
        {
            Debug.Log("Not enough money");
            return;
        }

        Vector3 offsetPos= new Vector3(transform.position.x,transform.position.y + offset,transform.position.z);
        turret = (GameObject)Instantiate(selTurret, offsetPos, transform.rotation);
        turretInfo = turret.GetComponent<Turret>();
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
