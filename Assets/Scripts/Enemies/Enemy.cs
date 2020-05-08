using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public float health;
    public float moveSpeed;
    public float scaleFactor;
    public int enemyScore;
    public int bounty;

    private EnemySpawnSystem spawnSystem;
    private BuildSystem _buildSystem;
    private Player _player;

    private void Start()
    {
        //Difficulty is increased by increasing the health of the enemy.
        //Health is scaled by the current wave and a specified scale factor.
        spawnSystem = GameObject.Find("UniversalManager").GetComponent<EnemySpawnSystem>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        health *= (scaleFactor * spawnSystem.currentWave);
        _buildSystem = GameObject.Find("UniversalManager").GetComponent<BuildSystem>();
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
    }

    private void Death()
    {
        _player.score += enemyScore;
        _buildSystem.playerMoney += bounty;
        Destroy(this.gameObject); 
    }
}

        
