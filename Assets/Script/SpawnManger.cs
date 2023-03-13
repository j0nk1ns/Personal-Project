using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
   //variables necssary for SpawnManager. Adjust values as Desired
   public GameObject enemyPrefab;
   private float spawnRange;
   public int enemyCount;
   public int waveNumber; 
   
   
    // Start is called before the first frame update
    void Start()
    {
      SpawnEnemyWave(waveNumber);  
    }

    //generates coordinates for new enemy spawn postion 
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0) 
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        } 
    }
}
