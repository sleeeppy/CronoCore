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

            Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitResult;

            if (Physics.Raycast(ray, out hitResult))
            {
                StartCoroutine(Dashing(hitResult));
            }


            // ��ų Cool ���� Couroutine
            StartCoroutine(SC_Cool());
        }
    }
    IEnumerator Dashing(RaycastHit hitResult)
    {
        isDashing = true;

        // ĳ������ ��ġ�� �������� ���콺 Ŀ������ ���� ���͸� ����մϴ�.
        Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;

        Vector3 targetPosition = transform.position + mouseDir.normalized * dashDistance; // ���� ���͸� ����ȭ�Ͽ� �Ÿ���ŭ�� �̵�

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position += mouseDir.normalized * dashSpeed * Time.deltaTime; // ���� ���͸� ����ȭ�Ͽ� �̵�
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
