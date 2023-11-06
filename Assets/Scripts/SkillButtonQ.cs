using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonQ : MonoBehaviour
{
    public Image imgIcon; // ��ų �̹���
    public Image imgCool; // Cooldown �̹���

    public bool Use = false;

    EnemyMove enemy;

    void Start()
    {
        enemy = FindObjectOfType<EnemyMove>();
        imgCool.fillAmount = 0; // Cool �̹��� �ʱ� ����
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!Use)
            {
                // Cool �̹����� fillAmount�� 0���� ũ�� ��Ÿ���� ������ �ʾҴٴ� ��
                if (imgCool.fillAmount > 0) return;

                Use = true;
                enemy.TimeStop();
                Invoke("Stop", 5.0f);

                // ��ų Cool ���� Couroutine
                StartCoroutine(SC_Cool());
            }
            else
            {
                enemy.MoveTrue();
                Use = false;
            }
        }
    }

    public void Stop()
    {
        enemy.MoveTrue();
        Use = false;
    }

    IEnumerator SC_Cool()
    {
        // skill.cool ���� ���� �޶���
        float tick = 1f;
        float t = 0;

        imgCool.fillAmount = 1;

        // 10�ʿ� ���� 1->0���� ���� �ϴ� ���� imgCool.fillAmount�� �־���
        while (imgCool.fillAmount > 0)
        {
            imgCool.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }
    }
}