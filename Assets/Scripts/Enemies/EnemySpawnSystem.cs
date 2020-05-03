using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public GameObject enemy;
        public bool isBoss;
        public int numEnemies;
        public float spawnRate;
    }

    [Header("System Objects")]
    public Wave[] waves;
    public Transform[] spawnPoints;

    [Header("System States")]
    public bool isWaiting;
    public bool isSpawning;
    public bool waveTimer;

    [Header("System Values")]
    public byte waveIndex;
    public long currentWave;
    public float timeBeforeNextWave;
    public float waveTime;
    public float checkInterval;

    private void Awake()
    {
        //Set defaults.
        waveIndex = 0;
        currentWave = 0;
        checkInterval = 5f;
        waveTime = timeBeforeNextWave;

        waveTimer = true;
        isWaiting = false;
        isSpawning = false;
    }

    private void Update()
    {
        if(waveTimer && waveTime <= 0)
        {
            currentWave++;
            isSpawning = true;
            waveTimer = false;
        }
        else if(waveTimer)
        {
            waveTime -= Time.deltaTime;
            return;
        }

        if (isWaiting)
        {
            if (!EnemyAlive())
            {
                waveTime = timeBeforeNextWave;
                waveTimer = true;
                isWaiting = false;
                return;
            }
            else
            {
                return;
            }
        }

        if(isSpawning)
        {
            StartCoroutine(SpawnWave(waves[waveIndex]));
            isSpawning = false;
        }
    }

    public bool EnemyAlive()
    {
        //We check if enemies are alive at an interval to reduce stress on the engine.
        checkInterval -= Time.deltaTime;
        if( checkInterval <= 0f)
        {
            checkInterval = 5f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                if(waveIndex == waves.Length - 1){ waveIndex = 0; } else { waveIndex++; }
                return false;
            }
        }

        return true;
    }

     IEnumerator SpawnWave(Wave toSpawn)
    {
        //For loop to spawn enemies a number of times, given the size of the wave.
        for(int x = 0; x < toSpawn.numEnemies; x++)
        {
            SpawnEnemy(toSpawn.enemy);
            yield return new WaitForSeconds(1f/toSpawn.spawnRate);
        }

        isWaiting = true;
        yield break;
    }

    void SpawnEnemy(GameObject enemy)
    {
        int rndIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[rndIndex].transform.position, spawnPoints[rndIndex].transform.rotation);
    }
}
