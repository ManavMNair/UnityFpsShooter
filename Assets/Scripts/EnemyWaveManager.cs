using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; 
    public int startEnemyCount = 3;
    public float timeBetweenWaves = 3f;

    private int currentWave = 0;
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnWaveLoop());
    }

    IEnumerator SpawnWaveLoop()
    {
        while (true)
        {
            // Wait for all enemies to be cleared
            while (enemies.Count > 0)
            {
                enemies.RemoveAll(e => e == null); 
                yield return null;
            }

            yield return new WaitForSeconds(timeBetweenWaves);

            currentWave++;
            int enemyCount = startEnemyCount + currentWave;

            Debug.Log($"Wave {currentWave} begins with {enemyCount} enemies!");

            SpawnEnemies(enemyCount);
        }
    }

    void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemies.Add(enemy);
        }
    }
}
