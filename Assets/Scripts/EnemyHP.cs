using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int enemyHP = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // OnTriggerEnter �Լ��� ����Ͽ� IsTrigger�� Ȱ��ȭ�� �Ѿ˰��� �浹�� ó���մϴ�.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHP = enemyHP - 1;
        }
    }
}