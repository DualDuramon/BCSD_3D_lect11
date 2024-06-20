using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어를 추적 로직
        Vector3 lookDirection
            = (player.transform.position - transform.position).normalized; //플레이어를 향하는 정규화된 벡터
        enemyRb.AddForce(lookDirection * speed);
    }
}
