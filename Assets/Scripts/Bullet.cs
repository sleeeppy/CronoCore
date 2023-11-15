using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isFire;
    Vector3 direction;
    [SerializeField]
    float speed = 1.0f;

    private GameObject Damage;
    private float Dam;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // �������� ������ ���� �ʵ��� ����
        rb.useGravity = false; // �߷� ������ ���� �ʵ��� ����

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        if (isFire)
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    public void Fire(Vector3 dir)
    {
        direction = dir;
        isFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage = GameObject.Find("Player");
            Dam = Damage.GetComponent<SimpleCharacterController>().BulDamUp();
            other.gameObject.GetComponent<EnemyHP>().enemyHP -= Dam;
            Destroy(gameObject);
        }
    }
}