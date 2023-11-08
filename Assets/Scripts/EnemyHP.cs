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

    // OnTriggerEnter 함수를 사용하여 IsTrigger가 활성화된 총알과의 충돌을 처리합니다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHP = enemyHP - 1;
        }
    }
}