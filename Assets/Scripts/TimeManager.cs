using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public GameObject bossspawn;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI Timescale;
    private float timeLeft = 120.0f;
    private bool TimeSetBoss = false;
    private float Scale = 1f;

    void Update()
    {
        Timescale.text = "x  " + Scale;

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

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (Scale < 2f)
            {
                Scale += 0.1f;
                Time.timeScale = Scale;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (Scale > 0.5f)
            {
                Scale -= 0.1f;
                Time.timeScale = Scale;
            }
        }
    }
}