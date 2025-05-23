using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;

    public GameObject enemyPrefab;
    public int poolSize = 20;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            pool.Add(enemy);
        }
    }

    public GameObject GetEnemy()
    {
        foreach (GameObject enemy in pool)
        {
            if (!enemy.activeInHierarchy)
                return enemy;
        }

        // Optional: Expand pool if needed
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        pool.Add(newEnemy);
        return newEnemy;
    }
}
