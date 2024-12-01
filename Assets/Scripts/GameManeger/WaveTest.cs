using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTest : MonoBehaviour
{
    [SerializeField] private int enemiesCount;
    [SerializeField] private int maxEnemies;
    [SerializeField] private int bossCount;
    [SerializeField] private int maxBoss;
    [SerializeField] private int currentItemCount;
    [SerializeField] private int maxItems;
    [SerializeField] private TimeSystem timeSystem;
    [SerializeField] private float timeForBoss;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] boss;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnRadius;
    [SerializeField] private GameObject[] currency;
    [SerializeField] private GameObject[] currencySpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeSystem = FindObjectOfType<TimeSystem>();
        timeForBoss = timeSystem.nSec / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //count enemies in scence
        currentItemCount = GameObject.FindGameObjectsWithTag("Currency").Length;
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        bossCount = GameObject.FindGameObjectsWithTag("Boss").Length;
        //night
        if (timeSystem.isDay == false)
        {
            NightWave();
        }

        if (timeSystem.isDay == true)
        {
            DayWave();
        }
    }

    void NightWave()
    {
        //make spawn pos as a circle radius area around player
        Vector2 randomSpawnPos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(player.transform.position.x + randomSpawnPos.x,
            player.transform.position.y,
            player.transform.position.z + randomSpawnPos.y);
        
        if (enemiesCount < maxEnemies)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity); 
        }

        if (timeSystem.currentNsec <= timeForBoss && bossCount < maxBoss)
        {
            Instantiate(boss[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        }
        
    }
    void DayWave()
    {
       
        // 1.RANDOM POSITION OF DROPZONE
        // 2.EVERY DROPZONE MUST INSTANIATE RANDOM ITEMS
        // 3.RANDOM ITEM
        foreach (GameObject spawnPoint in currencySpawnPoints)
        {
            if (spawnPoint != null && currentItemCount < maxItems)
            {
                // Generate a random offset within a spawn radius around the spawn point
                Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
                Vector3 randomPosition = new Vector3(
                    spawnPoint.transform.position.x + randomOffset.x,
                    spawnPoint.transform.position.y,
                    spawnPoint.transform.position.z + randomOffset.y
                );

                // Randomly pick an item from the currency array
                GameObject randomItem = currency[Random.Range(0, currency.Length)];

                // Instantiate the random item at the calculated random position
                Instantiate(randomItem, randomPosition, Quaternion.identity);
            }
        }
        
    }
}
