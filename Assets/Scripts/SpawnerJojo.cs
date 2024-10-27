using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerJojo : MonoBehaviour
{
    public GameObject[] jojo;
    public float spawnRate = 1f;
    private float lastSpawnTime;

    public float minX = 15f;
    public float maxX = 20f;

    void Start()
    {
        SpawnTowerJojo();
    }

    void Update()
    {
        if (Time.time > lastSpawnTime + spawnRate)
        {
            SpawnTowerJojo();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnTowerJojo()
    {
        float randomX = UnityEngine.Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 8f, transform.position.z);
        int randomIndex = UnityEngine.Random.Range(0, jojo.Length);
        GameObject selectedTower = jojo[randomIndex];
        Instantiate(selectedTower, spawnPosition, Quaternion.identity);
    }
}