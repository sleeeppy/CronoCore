using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoreUI : MonoBehaviour
{
    public TMP_Text tmp;

    private void Start()
    {
        tmp.text = "";
    }
}
