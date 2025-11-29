using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyM : MonoBehaviour
{
    public static EnemyM instance;
    public GameObject enemyPrefab;
    public Vector2 xRange;
    public Vector2 zRange;
    
    private int count = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnEnemies(5);
    }

    private void SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float x = Random.Range(xRange.x, xRange.y);
            float z = Random.Range(zRange.x, zRange.y);
            Instantiate(enemyPrefab, new Vector3(x, 1f, z), Quaternion.identity);
            count++;
        }
    }

    public void RemoveEnemy()
    {
        count--;

        if (count <= 2)
        {
            SpawnEnemies(3);
        }
    }
}