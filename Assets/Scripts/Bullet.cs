using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isFire;
    Vector3 direction;
    [SerializeField]
    float speed = 1.0f;

    void Start()
    {
        // Rigidbody 컴포넌트를 추가하여 물리적인 충돌을 처리할 수 있도록 합니다.
        // Rigidbody 컴포넌트는 IsTrigger를 사용하기 위해 필요합니다.
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // 물리적인 영향을 받지 않도록 설정
        rb.useGravity = false; // 중력 영향을 받지 않도록 설정

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
            Destroy(gameObject);
        }
    }
}