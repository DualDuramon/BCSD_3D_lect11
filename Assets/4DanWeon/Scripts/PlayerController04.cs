using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController04 : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;  //ī�޶��� ȸ������ ������Ʈ
    private float powerUpStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //ī�޶� ���� ������ �� �ڷ� �����̰� ��.
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); //�Ŀ��� �ε������� ��ġ ����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) //�Ŀ��� ���� Ȱ��ȭ
        {
            hasPowerup = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());  //�Ŀ������� �ڷ�ƾ �Լ� ����

        }
    }

    IEnumerator PowerUpCountdownRoutine()   //�Ŀ������� �ڷ�ƾ �Լ�
    {
        //7�ʸ� ��ٸ� �� powerup ���¸� ����
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) //�Ŀ��� ���¿��� ���� �浹��
        {
            //�� ������Ʈ ƨ�ܳ��� ����
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log($"Collided with {collision.gameObject.name} with powerup set to {hasPowerup}");
        }
    }
}
