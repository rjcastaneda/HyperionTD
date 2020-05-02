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

    private EnemySpawnSystem spawnSystem;
    private Player _player;

    private void Awake()
    {
        //Difficulty is increased by increasing the health of the enemy.
        //Health is scaled by the current wave and a specified scale factor.
        spawnSystem = GameObject.Find("UniversalManager").GetComponent<EnemySpawnSystem>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        health *= (scaleFactor * spawnSystem.currentWave);
    }

    private void Update()
    {
        if (health <= 0){ Death();  }
    }

    void OnCollisionEnter(Collision collision)
    {

        //Upon reaching the exit, we must 
        if (collision.gameObject.CompareTag("EnemyExit"))
        {
            _player.health -= 1;
            Destroy(this.gameObject);
        }
    }


    private void Death()
    {
        _player.score += enemyScore;
        Destroy(this.gameObject); 
    }
}

        
