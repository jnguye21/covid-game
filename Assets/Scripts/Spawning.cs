using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawners = null;
    [SerializeField] private List<Sprite> spawnSprites = null;
    [SerializeField] private GameObject spawnPrefab = null;
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
        int randSpawner = Random.Range(0, spawners.Count);
        int randSprite = Random.Range(0, spawnSprites.Count);
        GameObject spawn = Instantiate(spawnPrefab, spawners[randSpawner].transform.position, Quaternion.identity);
        spawn.gameObject.GetComponent<SpriteRenderer>().sprite = spawnSprites[randSprite];
    }
}
