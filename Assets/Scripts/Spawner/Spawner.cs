using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject[] itemsToSpawn;
    [SerializeField] private GameObject[] enemiesToSpawn;

    [Header("Item Spawn")] 
    [SerializeField] public bool spawnItem;
    [SerializeField] private int[] itemSpawnAmounts; // จำนวนที่กำหนดสำหรับแต่ละไอเท็มใน itemsToSpawn

    [Header("Enemies Spawn")] 
    [SerializeField] public bool spawnEnemies;
    [SerializeField] private int[] enemiesSpawnAmounts; // จำนวนที่กำหนดสำหรับแต่ละศัตรู

    void Start()
    {
        
    }

    void Update()
    {
        if (spawnItem)
        {
            SpawnItem();
            spawnItem = false; // ปิดการ Spawn หลังทำงานเสร็จ
        }

        if (spawnEnemies)
        {
            SpawnEnemies();
            spawnEnemies = false; // ปิดการ Spawn หลังทำงานเสร็จ
        }
    }

    
    public void SpawnItem()
    {
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            int amountToSpawn = itemSpawnAmounts[i];
            for (int j = 0; j < amountToSpawn; j++)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                Instantiate(itemsToSpawn[i], transform.position + randomOffset, Quaternion.identity);
                Debug.Log($"Spawned Item {i}: {j + 1}/{amountToSpawn}");
            }
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn.Length; i++)
        {
            int amountToSpawn = enemiesSpawnAmounts[i];
            for (int j = 0; j < amountToSpawn; j++)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                Instantiate(enemiesToSpawn[i], transform.position + randomOffset, Quaternion.identity);
                Debug.Log($"Spawned Enemy {i}: {j + 1}/{amountToSpawn}");
            }
        }
    }
}
