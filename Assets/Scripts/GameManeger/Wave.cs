using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField]private TimeSystem timeSystem;
    public WaveManager[] wavesCount;
    [SerializeField]private int currentWave = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnRadius;
    [SerializeField] private bool spawned;
    [SerializeField] private int enemiesCount;
    [Header("UI")]
    [SerializeField] private GameObject waveUI;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemiesCountText;
    
    // Start is called before the first frame update
    void Start()
    {
        timeSystem = GetComponent<TimeSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSystem.isDay == false)
        {
            waveUI.SetActive(true);
        }

        if (timeSystem.isDay == true)
        {
            waveUI.SetActive(false);
        }
        EnemiesCount();
        SetText();
        if (timeSystem.isDay == false && spawned == false)
        {
            spawned = true;
            SpawnWave();
        }

        if (spawned == true && enemiesCount <= 0)
        {
            if (currentWave+1 != wavesCount.Length)
            {
                currentWave++;
            }
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < wavesCount[currentWave].enemies.Length; i++)
        {
            Vector2 randomSpawnPos = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPos = new Vector3(player.transform.position.x + randomSpawnPos.x,
                player.transform.position.y,
                player.transform.position.z + randomSpawnPos.y);
            
            Instantiate(wavesCount[currentWave].enemies[i],spawnPos,Quaternion.identity);
        }
    }

    private void SetText()
    {
        enemiesCountText.SetText($"ENEMIES LEFT : {enemiesCount}");
        waveText.SetText($"WAVE {currentWave+1}/{wavesCount.Length}");
    }

    private void EnemiesCount()
    {
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
   
}
[System.Serializable]
public class WaveManager
{ 
    public Enemy[] enemies;
}
