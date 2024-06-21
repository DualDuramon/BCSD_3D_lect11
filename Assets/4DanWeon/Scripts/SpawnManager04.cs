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
            //������ ��ġ�� �� ������Ʈ ����
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; //���� ���� ������

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpObject, GenerateSpawnPosition(), powerUpObject.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition() //���� ��ġ ���� �Լ�
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return spawnPos;
    }



}
