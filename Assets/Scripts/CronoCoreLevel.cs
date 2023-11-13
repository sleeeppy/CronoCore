using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CronoCoreLevel : MonoBehaviour
{
    public Slider CoreGauge;
    public int currentGauge = 0;
    public int MaxGauge;

    void Update()
    {
        CoreGauge.value = MaxGauge - (MaxGauge - currentGauge);
    }
}
