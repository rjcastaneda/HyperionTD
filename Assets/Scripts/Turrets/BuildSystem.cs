using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public int playerMoney;

    private GameObject selectedTurret;
    private GameObject machineGunTurret;
    private GameObject sniperTurret;
    private GameObject flameTurret;

    private void Start()
    {
        machineGunTurret = Resources.Load<GameObject>("Turrets/MGT");
    }

    public GameObject SelectTurret() { return selectedTurret; }
    public void SelMGT() { selectedTurret = machineGunTurret; }
    public void SelST() { selectedTurret = sniperTurret; }
    public void SelFT() { selectedTurret = flameTurret; }
}
