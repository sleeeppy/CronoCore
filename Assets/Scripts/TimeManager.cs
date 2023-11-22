using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public GameObject bossspawn;
    public TextMeshProUGUI timerText;
    private float timeLeft = 120.0f;
    private bool TimeSetBoss = false;

    void Update()
    {
        if (timeLeft >= -3)
        {
            timeLeft -= Time.deltaTime;

            string minutes = ((int)timeLeft / 60).ToString();
            string seconds = (timeLeft % 60).ToString("f2");

            if (timeLeft < 0)
            {
                timerText.text = "보스 등장까지 남은 시간 : 0:0.0";
            }
            else timerText.text = "보스 등장까지 남은 시간 : " + minutes + ":" + seconds;
        }
        else if (!TimeSetBoss)
        {
            TimeSetBoss = true;
            bossspawn.GetComponent<BossSpawn>().TimeOut = true;
            timerText.text = "";
        }
    }
}