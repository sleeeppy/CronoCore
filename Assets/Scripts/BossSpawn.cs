using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    private bool SetOn = false;
    public bool TimeOut = false;
    private bool TimeSpawn = false;
    public GameObject InvTime;
    public GameObject CoreLevel;

    private void Start()
    {
        for (int i = 0; transform.GetChild(i).name != "End"; i++)
        {
            CoreLevel.GetComponent<CronoCoreLevel>().MaxGauge = i + 1;
            CoreLevel.GetComponent<CronoCoreLevel>().CoreGauge.maxValue = i + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeOut && !TimeSpawn && !SetOn)
        {
            TimeSpawn = true;
            Invoke("TimeOutSet", 1f);
        }

        if (!SetOn && transform.GetChild(0).name == "End")
        {
            if (!TimeOut)
            {
                SetOn = true;
                Invoke("Set", 1f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void TimeOutSet()
    {
        Instantiate(Boss, transform.position, Quaternion.identity); 
    }

    void Set()
    {
        Instantiate(Boss, transform.position, Quaternion.identity);
        InvTime.GetComponent<TimeManager>().InvTimeOn = true;
        Destroy(gameObject);
    }
}