using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Core : MonoBehaviour
{
    public bool Dest = false;
    public GameObject UI;

    void Start()
    {
        Dest = false;
        UI = GameObject.Find("GetCore");
    }

    private void Update()
    {
        if (Dest)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            UI.GetComponent<CoreUI>().tmp.text = "[F] ащ╠Б";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            UI.GetComponent<CoreUI>().tmp.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UI.GetComponent<CoreUI>().tmp.text = "";
                Destroy(gameObject);
            }
        }
    }
}
