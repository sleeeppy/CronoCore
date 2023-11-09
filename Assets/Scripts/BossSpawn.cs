using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    public bool SetOn = false;

    // Update is called once per frame
    void Update()
    {
        if (!SetOn)
        {
            if (transform.GetChild(0).name == "end")
            {
                SetOn = true;
                Invoke("Set", 1f);
            }
        }
    }

    void Set()
    {
        Instantiate(Boss, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}