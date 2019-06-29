using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float distantCloudSpawnTimeMin;
    public float distantCloudSpawnTimeMax;
    float distantCloudSpawnTimer;

    public float midCloudSpawnTimeMin;
    public float midCloudSpawnTimeMax;
    float midCloudSpawnTimer;

    public float foregroundCloudSpawnTimeMin;
    public float foregroundCloudSpawnTimeMax;
    float foregroundCloudSpawnTimer;

    public GameObject cloudPrefab;



    void Start()
    {
        distantCloudSpawnTimer = Random.Range(distantCloudSpawnTimeMin, distantCloudSpawnTimeMax);
        midCloudSpawnTimer = Random.Range(midCloudSpawnTimeMin, midCloudSpawnTimeMax);
        foregroundCloudSpawnTimer = Random.Range(foregroundCloudSpawnTimeMin, foregroundCloudSpawnTimeMax);
    }

    void Update()
    {
        distantCloudSpawnTimer -= Time.deltaTime;
        if (distantCloudSpawnTimer <= 0)
        {
            distantCloudSpawnTimer = Random.Range(distantCloudSpawnTimeMin, distantCloudSpawnTimeMax);
            GameObject newCloud = Instantiate(cloudPrefab);
            newCloud.GetComponent<Cloud>().Init(Cloud.Distance.Far);
        }

        midCloudSpawnTimer -= Time.deltaTime;
        if (midCloudSpawnTimer <= 0)
        {
            midCloudSpawnTimer = Random.Range(midCloudSpawnTimeMin, midCloudSpawnTimeMax);
            GameObject newCloud = Instantiate(cloudPrefab);
            newCloud.GetComponent<Cloud>().Init(Cloud.Distance.Mid);
        }

        foregroundCloudSpawnTimer -= Time.deltaTime;
        if (foregroundCloudSpawnTimer <= 0)
        {
            foregroundCloudSpawnTimer = Random.Range(foregroundCloudSpawnTimeMin, foregroundCloudSpawnTimeMax);
            GameObject newCloud = Instantiate(cloudPrefab);
            newCloud.GetComponent<Cloud>().Init(Cloud.Distance.Close);
        }
    }
}