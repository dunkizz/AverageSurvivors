using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject[] itemsToSpawn;
    [SerializeField] private GameObject[] enemiesToSpawn;

    [Header("Item Spawn")] 
    [SerializeField] private bool spawnItem;
    [SerializeField] private int[] itemSpawnAmounts; // จำนวนที่กำหนดสำหรับแต่ละไอเท็มใน itemsToSpawn

    [Header("Enemies Spawn")] 
    [SerializeField] private bool spawnEnemies;
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

    
    void SpawnItem()
    {
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            int amountToSpawn = itemSpawnAmounts[i];
            for (int j = 0; j < amountToSpawn; j++)
            {
                Instantiate(itemsToSpawn[i], transform.position, Quaternion.identity);
                Debug.Log($"Spawned Item {i}: {j + 1}/{amountToSpawn}");
            }
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn.Length; i++)
        {
            int amountToSpawn = enemiesSpawnAmounts[i];
            for (int j = 0; j < amountToSpawn; j++)
            {
                Instantiate(enemiesToSpawn[i], transform.position, Quaternion.identity);
                Debug.Log($"Spawned Enemy {i}: {j + 1}/{amountToSpawn}");
            }
        }
    }
}
