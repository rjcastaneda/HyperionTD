﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSquare : MonoBehaviour
{
    public Color onHover;
    public Color startColor;

    private BuildSystem _buildSystem;
    private Renderer thisRend;

    private GameObject turret;
    private GameObject selTurret;
    private GameObject hologram;
    private void Start()
    {
        thisRend = this.gameObject.GetComponent<Renderer>();
        startColor = thisRend.material.color;
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
    }

    void OnMouseDown()
    {
        int turretCost;

        if(turret != null)
        { 
            Debug.Log("Can't build here");
            return; 
        }

        selTurret = _buildSystem.SelectTurret();
        turretCost = selTurret.GetComponent<Turret>().cost;

        if(turretCost > _buildSystem.playerMoney)
        {
            Debug.Log("Not enough money");
            return;
        }

        turret = (GameObject)Instantiate(selTurret, transform.position, transform.rotation);
        
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
