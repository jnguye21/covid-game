using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawners = null;
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private float spawnTimer = 1.5f;

    void Update()
    {
        if(spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = spawnRate;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        int randSpawner = UnityEngine.Random.Range(0, spawners.Count);
        Instantiate(enemyPrefab, spawners[randSpawner].transform.position, Quaternion.identity);
    }
}
