using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager04 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpObject;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpObject, GenerateSpawnPosition(), powerUpObject.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //랜덤한 위치에 적 오브젝트 생성
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; //적의 수를 가져옴

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpObject, GenerateSpawnPosition(), powerUpObject.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition() //랜덤 위치 생성 함수
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return spawnPos;
    }



}
