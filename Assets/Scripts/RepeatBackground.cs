using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //같은 배경 2장이 이어져있으므로 반으로 나눈 값을 사용.
    }

    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) //백그라운드 스크롤링
        {
            transform.position = startPos;
        }
    }
}
