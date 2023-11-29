using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public SimpleCharacterController player;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }
}
