using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager04 : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    void Start()
    {
        //랜덤한 위치에 적 오브젝트 생성
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition() //랜덤 위치 생성 함수
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
