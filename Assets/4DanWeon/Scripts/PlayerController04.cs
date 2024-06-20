using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController04 : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;  //카메라의 회전기준 오브젝트
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //카메라가 보는 방향의 앞 뒤로 움직이게 함.
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

    }
}
