using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public Rigidbody target;

    public bool isMove = true;

    private bool isLive = true;
    private Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isMove)
        {
            if (isLive)
            {
                MoveTowardsTarget();
            }
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
}
