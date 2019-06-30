using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflaterSpawner : MonoBehaviour
{
    public float minSpawnTimer;
    public float maxSpawnTimer;
    float spawnTimer;

    public GameObject deflaterPrefab;

    void Start()
    {
        spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
            Instantiate(deflaterPrefab);
        }
    }
}