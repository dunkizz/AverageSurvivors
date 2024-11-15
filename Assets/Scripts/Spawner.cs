using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 spawnPosition;
    private float dropSuccesVar;
    bool drop;
    
    [Header("Thing to Spawn")]
    [SerializeField]private GameObject[] itemToSpawn;
    [SerializeField]private GameObject[] enemyToSpawn;

    [Header("Spawner Settings")] 
    
    [SerializeField]private bool itemSpawn;
    [SerializeField]private float itemDropRate;
    [SerializeField]private int itemIdToSpawn;
    [SerializeField]private bool enemySpawn;
    [SerializeField]private int enemyIdToSpawn;
    [SerializeField]private int spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        if (drop == true)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        if (itemSpawn == true)
        {
            spawnPosition = this.transform.position;
            for (int i = 0; i < spawnCount; i++)
                Instantiate(itemToSpawn[itemIdToSpawn],spawnPosition,Quaternion.identity);
        }
    }

    void SpawnEnemy()
    {
        if (enemySpawn == true)
        {
            spawnPosition = this.transform.position;
            for (int i = 0; i < spawnCount; i++)
                Instantiate(itemToSpawn[enemyIdToSpawn],spawnPosition,Quaternion.identity);
        }
    }

    void DropRate()
    {
        float dropRateResult;
        bool drop;
        dropRateResult = UnityEngine.Random.Range(itemDropRate, 100f);
        if (dropRateResult > 70f)
        {
            drop = true;
        }

    }
}
