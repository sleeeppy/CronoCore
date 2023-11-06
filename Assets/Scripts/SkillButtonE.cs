using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonE : MonoBehaviour
{
    public Image imgIcon; // ��ų �̹���
    public Image imgCool; // Cooldown �̹���

    [SerializeField]
    private Animator animator;
    Camera characterCamera;

    public float dashSpeed = 10.0f;
    public float dashDistance = 0.5f;

    private bool isDashing = false;



    void Start()
    {
        imgCool.fillAmount = 0; // Cool �̹��� �ʱ� ����
        characterCamera = Camera.main;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            // Cool �̹����� fillAmount�� 0���� ũ�� ��Ÿ���� ������ �ʾҴٴ� ��
            if (imgCool.fillAmount > 0) return;

                StartCoroutine(Dashing());

            // ��ų Cool ���� Couroutine
            StartCoroutine(SC_Cool());
        }
    }
    IEnumerator Dashing()
    {
        isDashing = true;

        Vector3 dashDirection = animator.transform.forward;
        Vector3 targetPosition = transform.position + dashDirection * dashDistance;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * dashSpeed);
            yield return null;
        }
        isDashing = false;
    }

    IEnumerator SC_Cool()
    {
        // skill.cool ���� ���� �޶���
        float tick = 0.5f;
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
