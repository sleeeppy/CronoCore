using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    public GameObject corePrefab;

    void OnDestroy()
    {
        Instantiate(corePrefab, transform.position, Quaternion.identity);
    }
}
