using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager04 : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    void Start()
    {
        //������ ��ġ�� �� ������Ʈ ����
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition() //���� ��ġ ���� �Լ�
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return spawnPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
