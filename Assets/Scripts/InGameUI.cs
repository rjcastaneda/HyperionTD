using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    private GameObject BPButtonOne;
    private GameObject BuildPanel;

    public void Start()
    {
        BPButtonOne = GameObject.Find("BPButtonEN");
        BuildPanel = GameObject.Find("InGameUI").transform.Find("BuildPanel").gameObject;
    }

    public void BuildPanelEnable()
    {
        BuildPanel.SetActive(true);
        BPButtonOne.SetActive(false);
    }

    public void BuildPanelDisable()
    {
        BuildPanel.SetActive(false);
        BPButtonOne.SetActive(true);
    }
}
