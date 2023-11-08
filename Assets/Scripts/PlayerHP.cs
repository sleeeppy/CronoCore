using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public Slider HPbar;
    public float currentHP;
    public float maxHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.value = currentHP / maxHP;

        if (currentHP == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHP -= 1;
        }
    }
}
