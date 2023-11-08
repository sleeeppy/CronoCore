using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonQ : MonoBehaviour
{
    public Image imgIcon; // ��ų �̹���
    public Image imgCool; // Cooldown �̹���

    public bool Use = false;

    void Start()
    {
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

                // ���ʹ̹��� ��ũ��Ʈ�� ���� ��� ������Ʈ�� ���� ���� ����
                EnemyMove[] enemies = FindObjectsOfType<EnemyMove>();
                foreach (EnemyMove enemy in enemies)
                {
                    enemy.TimeStop();
                }

                Invoke("Stop", 2.5f);

                // ��ų Cool ���� Coroutine
                StartCoroutine(SC_Cool());
            }
            else
            {
                // ���ʹ̹��� ��ũ��Ʈ�� ���� ��� ������Ʈ�� ���� ���� ����
                EnemyMove[] enemies = FindObjectsOfType<EnemyMove>();
                foreach (EnemyMove enemy in enemies)
                {
                    enemy.MoveTrue();
                }

                Use = false;
            }
        }
    }

    public void Stop()
    {
        // ���ʹ̹��� ��ũ��Ʈ�� ���� ��� ������Ʈ�� ���� ���� ����
        EnemyMove[] enemies = FindObjectsOfType<EnemyMove>();
        foreach (EnemyMove enemy in enemies)
        {
            enemy.MoveTrue();
        }

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