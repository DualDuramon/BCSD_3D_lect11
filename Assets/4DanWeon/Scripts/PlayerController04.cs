using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController04 : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;  //카메라의 회전기준 오브젝트
    public float speed = 5.0f;
    private float powerUpStrength = 15.0f;
    public bool hasPowerup = false;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());  //파워업해제 코루틴 함수 실행
        }
    }

    IEnumerator PowerUpCountdownRoutine()   //파워업해제 코루틴 함수
    {
        //7초를 기다린 후 powerup 상태를 해제
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) //파워업 상태에서 적과 충돌시
        {
            //적 오브젝트 튕겨내기 로직
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log($"Collided with {collision.gameObject.name} with powerup set to {hasPowerup}");
        }
    }
}
