using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public EnemyController[] enemies;
    public Transform[] spawnPoints;

    Wave currentWave;
    int currentWaveIndex;

    int enemiesRemaining;
    public int enemiesAlive;
    float nextSpawnTime;

    private void Start()
    {
        currentWaveIndex = -1;
        NextWave();
    }

    private void Update()
    {
        if (enemiesRemaining > 0 && Time.time >= nextSpawnTime)
        {
            enemiesRemaining--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            EnemyController enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }

        enemiesAlive = FindObjectsOfType<EnemyController>().Length;
        if (enemiesRemaining == 0 && enemiesAlive == 0)
        {
            StartCoroutine(NextWave());
        }
    }

    IEnumerator NextWave()
    {
        if (currentWaveIndex > -1)
        {
            currentWave.waveWalls.SetActive(false);
        }

        yield return new WaitForSeconds(2f);

        if (currentWaveIndex != waves.Length - 1)
        {
            currentWaveIndex++;
        }
        else
        {
            currentWaveIndex = 0;
        }
        
        currentWave = waves[currentWaveIndex];
        enemiesRemaining = currentWave.enemyCount;
        enemies = currentWave.enemyTypesInWave;
        spawnPoints = currentWave.spawnPoints;
        currentWave.waveWalls.SetActive(true);
    }

    [System.Serializable]
    public class Wave
    {
        public Transform[] spawnPoints;
        public EnemyController[] enemyTypesInWave;
        public int enemyCount;
        public float timeBetweenSpawns;
        public GameObject waveWalls;
    }
}
