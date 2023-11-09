using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    public GameObject player;
    public bool SetOn = false;

    // Update is called once per frame
    void Update()
    {
        if (!SetOn)
        {
            if (transform.GetChild(0).name == "end")
            {
                Invoke("Set", 1f);
                SetOn = true;
            }
        }
    }

    void Set()
    {
        Boss.SetActive(true);
        Boss.transform.position = new Vector3(player.transform.position.x, Boss.transform.position.y, player.transform.position.z - 15);
        Destroy(gameObject);
    }
}