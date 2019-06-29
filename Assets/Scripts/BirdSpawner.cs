using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public float minSpawnTimer;
    public float maxSpawnTimer;
    float spawnTimer;

    public GameObject birdPrefab;

    void Start()
    {
        spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(birdPrefab);
            spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
        }
    }
}