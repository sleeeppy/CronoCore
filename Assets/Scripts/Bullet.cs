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

    private void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
