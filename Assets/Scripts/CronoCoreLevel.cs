using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CronoCoreLevel : MonoBehaviour
{
    public Slider CoreGauge;
    public int currentGauge = 0;
    public int MaxGauge;

    private void Start()
    {
        CoreGauge.maxValue = MaxGauge;
    }

    void Update()
    {
        if (currentGauge > MaxGauge)
        {
            currentGauge = MaxGauge;
        }
        else CoreGauge.value = MaxGauge - (MaxGauge - currentGauge);
    }
}
