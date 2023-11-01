using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonQ : MonoBehaviour
{
    public Image imgIcon; // ��ų �̹���
    public Image imgCool; // Cooldown �̹���


    void Start()
    {

        imgCool.fillAmount = 0; // Cool �̹��� �ʱ� ����
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Cool �̹����� fillAmount�� 0���� ũ�� ��Ÿ���� ������ �ʾҴٴ� ��
            if (imgCool.fillAmount > 0) return;

            // ��ų Cool ���� Couroutine
            StartCoroutine(SC_Cool());
        }
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
