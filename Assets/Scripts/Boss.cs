using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject CorePrefab;
    private GameObject Char;

    private bool SkySpawn = true;

    private void Start()
    {
        Char = GameObject.Find("Player");
        if (SkySpawn)
        {
            transform.position = new Vector3(Char.transform.position.x, transform.position.y + 5, Char.transform.position.z + 10);
        }
        else
        {
            transform.position = new Vector3(Char.transform.position.x, transform.position.y - 5, Char.transform.position.z - 10);
        }
    }

    void OnDestroy()
    {
        Instantiate(CorePrefab, transform.position, Quaternion.identity);   
    }
}
