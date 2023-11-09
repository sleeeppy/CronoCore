using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject CorePrefab;
    public GameObject Char;

    private void Start()
    {
        Char = GameObject.Find("Player");
        transform.position = new Vector3(Char.transform.position.x, transform.position.y, Char.transform.position.z - 15);
    }

    void OnDestroy()
    {
        Instantiate(CorePrefab, transform.position, Quaternion.identity);
    }
}
