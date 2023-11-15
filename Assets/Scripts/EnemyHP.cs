using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float enemyHP = 10;
    private GameObject Gauge;

    private GameObject BulletDamage;

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            Gauge = GameObject.Find("CoreGauge");
            Gauge.GetComponent<CronoCoreLevel>().currentGauge += 1;

            BulletDamage = GameObject.Find("Player");
            BulletDamage.GetComponent<SimpleCharacterController>().BulDam += 0.3f;

            Destroy(this.gameObject);
        }
    }
}