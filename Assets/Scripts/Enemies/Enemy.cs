using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [Header("Script Objects")]
    private EnemySpawnSystem spawnSystem;
    private BuildSystem _buildSystem;
    private Player _player;

    [Header("Enemy Attributes")]
    public string enemyName;
    public float health;
    public float moveSpeed;
    public float scaleFactor;
    public float moneyScaleFactor;
    public int enemyScore;
    public int bounty;
    public GameObject deathEffect;

    private float baseHealth;

    [Header("EnemyUI")]
    public Image HealthBar;

    private void Start()
    {
        //Initializing variables
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
        spawnSystem = GameObject.Find("UniversalManager").GetComponent<EnemySpawnSystem>();
        _player = GameObject.Find("Player").GetComponent<Player>();

        //Difficulty is increased by increasing the health of the enemy.
        //Health/Bounty is scaled by the current wave and a specified scale factor.
        float healthScale = (health * scaleFactor);
        health += (healthScale * spawnSystem.currentWave);
        float bountyScale = (float)(bounty * moneyScaleFactor);
        bounty += (int)(bountyScale * spawnSystem.currentWave);
        baseHealth = health;
    }

    private void Update()
    {
        if (health <= 0){ Death();  }
    }

    void OnCollisionEnter(Collision collision)
    {

        //Upon reaching the exit, the enemy is destroyed
        //and player loses a life.
        if (collision.gameObject.CompareTag("EnemyExit"))
        {
            _player.health -= 1;
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        HealthBar.fillAmount = health / baseHealth;
    }

    private void Death()
    {
        _player.score += enemyScore;
        _buildSystem.playerMoney += bounty;
        GameObject DEffect = (GameObject)Instantiate(deathEffect, this.transform.position,deathEffect.transform.rotation);
        Destroy(DEffect, 1f);
        Destroy(this.gameObject); 
    }
}

        
