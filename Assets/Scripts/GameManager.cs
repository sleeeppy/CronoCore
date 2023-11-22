using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public SimpleCharacterController player;

    void Awake()
    {
        instance = this;
    }
}
