using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    public GameObject CorePrefab;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        Instantiate(CorePrefab, transform.position, Quaternion.identity);
    }
}
