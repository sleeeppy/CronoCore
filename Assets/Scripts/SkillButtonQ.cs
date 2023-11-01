using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonQ : MonoBehaviour
{
    public Image imgIcon; // 스킬 이미지
    public Image imgCool; // Cooldown 이미지


    void Start()
    {

        imgCool.fillAmount = 0; // Cool 이미지 초기 설정
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Cool 이미지의 fillAmount가 0보다 크면 쿨타임이 끝나지 않았다는 뜻
            if (imgCool.fillAmount > 0) return;

            // 스킬 Cool 관리 Couroutine
            StartCoroutine(SC_Cool());
        }
    }

    IEnumerator SC_Cool()
    {
        // skill.cool 값에 따라 달라짐
        float tick = 1f;
        float t = 0;

        imgCool.fillAmount = 1;

        // 10초에 걸쳐 1->0으로 변경 하는 값을 imgCool.fillAmount에 넣어줌
        while (imgCool.fillAmount > 0)
        {
            imgCool.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }
    }
}
