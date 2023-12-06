using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float enemyHP;
    private GameObject Gauge;
    private GameObject HPup;

    private GameObject BulletDamage;

    private void Start()
    {
        HPup = GameObject.Find("Timer");
        enemyHP += HPup.GetComponent<TimeManager>().UP();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            Gauge = GameObject.Find("CoreGauge");
            if (Gauge.GetComponent<CronoCoreLevel>().currentGauge < Gauge.GetComponent<CronoCoreLevel>().MaxGauge)
            {

                Gauge.GetComponent<CronoCoreLevel>().currentGauge += 1;

                BulletDamage = GameObject.Find("Player");
                BulletDamage.GetComponent<SimpleCharacterController>().BulDam += 0.1f;
            }

            Destroy(this.gameObject);
        }
    }
}