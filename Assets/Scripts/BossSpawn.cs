using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    public bool TimeOut = false;
    private bool spawn = false;
    public GameObject InvTime;
    public GameObject CoreLevel;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeOut && !spawn)
        {
            spawn = true;
            Instantiate(Boss, transform.position, Quaternion.identity);
        }
    }
}