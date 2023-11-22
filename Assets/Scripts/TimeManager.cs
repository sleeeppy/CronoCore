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
                timerText.text = "���� ������� ���� �ð� : 0:0.0";
            }
            else timerText.text = "���� ������� ���� �ð� : " + minutes + ":" + seconds;
        }
        else if (!TimeSetBoss)
        {
            TimeSetBoss = true;
            bossspawn.GetComponent<BossSpawn>().TimeOut = true;
            timerText.text = "";
        }
    }
}