using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);   //��������Ʈ ����.
    private float startDelay = 2;
    private float repeatRate = 2;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);   //startDelay�� �Ŀ� repeatRate�� �������� SpawnObstacle�Լ� ȣ��.
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);   //obstacle�������� spawnPos�� ����.
    }
}
