using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public float minSpawnTimer;
    public float maxSpawnTimer;
    float spawnTimer;

    public AudioClip[] cawSounds;
    AudioSource audioSource;

    public GameObject birdPrefab;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
            Instantiate(birdPrefab);
            if (Random.Range(0, 8) == 0)
            {
                audioSource.clip = cawSounds[Random.Range(0, cawSounds.Length - 1)];
                audioSource.Play();
            }
        }
    }
}