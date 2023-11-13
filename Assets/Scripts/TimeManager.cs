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

                string minutes = ((int)timeLeft / 60).ToString();  // ���� ���� ����մϴ�.
                string seconds = (timeLeft % 60).ToString("f2");  // ���� �ʸ� ����ϰ�, �Ҽ��� ��° �ڸ����� ǥ���մϴ�.

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
        else timerText.text = "";
    }
}