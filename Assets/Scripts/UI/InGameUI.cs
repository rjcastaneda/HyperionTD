using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    private GameObject BPButtonOne;
    private GameObject BuildPanel;
    private BuildSystem _buildSystem;
    private EnemySpawnSystem _enemySpawnSystem;
    private Player _player;

    private TextMeshProUGUI healthText;
    private TextMeshProUGUI bankText;
    private TextMeshProUGUI wavesText;
    private TextMeshProUGUI scoreText;

    [Header("Texts")]
    public GameObject healthTextGO;
    public GameObject bankTextGO;
    public GameObject wavesTextGO;
    public GameObject scoreTextGO;

    public void Start()
    {
        BPButtonOne = GameObject.Find("BPButtonEN");
        BuildPanel = GameObject.Find("InGameUI").transform.Find("BuildPanel").gameObject;
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
        _enemySpawnSystem = GameObject.Find("UniversalManager").GetComponent<EnemySpawnSystem>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        healthText = healthTextGO.GetComponent<TextMeshProUGUI>();
        bankText = bankTextGO.GetComponent<TextMeshProUGUI>();
        wavesText = wavesTextGO.GetComponent<TextMeshProUGUI>();
        scoreText = scoreTextGO.GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        UpdateHealth();
        UpdateBank();
        UpdateWaves();
        UpdateScore();
    }

    private void UpdateHealth()
    {
        healthText.text = "Health: " + _player.health.ToString();
    }

    private void UpdateBank()
    {
        bankText.text = "Bank: $" + _buildSystem.playerMoney.ToString();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + _player.score.ToString("D12");
    }

    private void UpdateWaves()
    {
        wavesText.text = "Wave: " + _enemySpawnSystem.currentWave.ToString();
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
