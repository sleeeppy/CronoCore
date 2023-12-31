using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    private Rigidbody target;

    private bool isMove = true;

    private bool isLive = true;
    private Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        target = GameObject.Find("BoxMan@Stand").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isLive && isMove)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - rigid.position).normalized;
        Vector3 nextPosition = direction * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextPosition);

        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            rigid.rotation = rotation;
        }

        rigid.velocity = Vector3.zero;
    }

    public void TimeStop()
    {
        isMove = false;
    }

    public void MoveTrue()
    {
        isMove = true;
    }

    void OnEnable()
    {
        target = GameObject.Find("BoxMan@Stand").GetComponent<Rigidbody>();
    }
}