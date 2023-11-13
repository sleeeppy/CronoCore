using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public GameObject bossspawn;
    public TextMeshProUGUI timerText;
    private float timeLeft = 120.0f;
    private bool TimeSetBoss = false;
    public bool InvTimeOn = false;

    void Update()
    {
        if (!InvTimeOn)
        {
            if (timeLeft >= -3)
            {
                timeLeft -= Time.deltaTime;

                string minutes = ((int)timeLeft / 60).ToString();  // 남은 분을 계산합니다.
                string seconds = (timeLeft % 60).ToString("f2");  // 남은 초를 계산하고, 소수점 둘째 자리까지 표시합니다.

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
        else timerText.text = "";
    }
}