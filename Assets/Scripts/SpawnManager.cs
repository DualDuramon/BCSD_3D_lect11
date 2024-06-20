using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);   //스폰포인트 지정.
    private float startDelay = 2;
    private float repeatRate = 2;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);   //startDelay초 후에 repeatRate초 간격으로 SpawnObstacle함수 호출.
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);   //obstacle프리팹을 spawnPos에 생성.
    }
}
