using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    public int maxEnemies = 10;

    private bool spawning = true;
    private int killCount = 0;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    System.Collections.IEnumerator SpawnEnemies()
    {
        while (spawning)
        {
            int activeEnemyCount = CountActiveEnemies();
            if (activeEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = EnemyPool.Instance.GetEnemy();
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        enemy.transform.position = point.position;
        enemy.transform.rotation = point.rotation;
        enemy.SetActive(true);
    }

 int CountActiveEnemies()
{
    int count = 0;
    foreach (Transform t in EnemyPool.Instance.GetComponentsInChildren<Transform>(true))
    {
        if (t.CompareTag("Enemy") && t.gameObject.activeInHierarchy)
            count++;
    }
    return count;
}
    public void StopSpawning()
    {
        spawning = false;
    }

    public void EnemyKilled()
    {
        killCount++;
        Debug.Log("Enemy Killed! Total kills: " + killCount);
    }

     public int GetKillCount()
    {
        return killCount;
    }
}
