using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] towersArray; 
    public float spawnRate = 1f;     
    private float lastSpawnTime;

    public float minX = 15f; 
    public float maxX = 20f; 

    void Start()
    {
        SpawnTower();
    }

    void Update()
    {
        if (Time.time > lastSpawnTime + spawnRate)
        {
            SpawnTower();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnTower()
    {
        float randomX = UnityEngine.Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 8f, transform.position.z);
        int randomIndex = UnityEngine.Random.Range(0, towersArray.Length);
        GameObject selectedTower = towersArray[randomIndex];
        Instantiate(selectedTower, spawnPosition, Quaternion.identity);
    }
}
