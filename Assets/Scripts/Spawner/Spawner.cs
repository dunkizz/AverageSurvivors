using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]private GameObject[] itemsToSpawn;
    [SerializeField]private GameObject[] enemiesToSpawn;

    [Header("Item Spawn")] 
    [SerializeField]private bool spawnItem;
    [SerializeField]private int itemIdToSpawn;
    [SerializeField]private int itemSpawnAmount;
    [SerializeField]private float itemDropRate;

    [Header("Enemies Spawn")] 
    [SerializeField]private bool spawnEnemies;
    [SerializeField] private int enemiesIdToSpawn;
    [SerializeField] private int enemiesSpawnAmount;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnItem == true)
        {
            SpawnItem();
        }

        if (spawnEnemies == true)
        {
            SpawnEnemies();
        }
    }

    void SpawnItem()
    {
        for (int i = 0; i < itemSpawnAmount; i++)
        {
            Instantiate(itemsToSpawn[itemIdToSpawn], transform.position, Quaternion.identity);
            Debug.Log($"Item {itemIdToSpawn} spawned : {i} ");
            if (i == itemSpawnAmount-1)
            {
                spawnItem = false;
            }
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesSpawnAmount; i++)
        {
            Instantiate(enemiesToSpawn[enemiesIdToSpawn], transform.position, Quaternion.identity);
            Debug.Log($"Enemy {enemiesIdToSpawn} spawned : {i} ");
            if (i == enemiesSpawnAmount-1)
            {
                spawnEnemies = false;
            }
        }
    }
}
