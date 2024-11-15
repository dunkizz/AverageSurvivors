using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]private GameObject[] itemToSpawn;
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
        
    }

    void SpawnEnemies()
    {
        
    }
}
