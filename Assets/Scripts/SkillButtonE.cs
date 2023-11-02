using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonE : MonoBehaviour
{
    public Image imgIcon; // 스킬 이미지
    public Image imgCool; // Cooldown 이미지

    [SerializeField]
    private Animator animator;
    Camera characterCamera;

    public float dashSpeed = 10.0f;
    public float dashDistance = 0.5f;

    private bool isDashing = false;



    void Start()
    {
        imgCool.fillAmount = 0; // Cool 이미지 초기 설정
        characterCamera = Camera.main;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            // Cool 이미지의 fillAmount가 0보다 크면 쿨타임이 끝나지 않았다는 뜻
            if (imgCool.fillAmount > 0) return;

            Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitResult;

            if (Physics.Raycast(ray, out hitResult))
            {
                StartCoroutine(Dashing(hitResult));
            }


            // 스킬 Cool 관리 Couroutine
            StartCoroutine(SC_Cool());
        }
    }
    IEnumerator Dashing(RaycastHit hitResult)
    {
        isDashing = true;

        // 캐릭터의 위치를 기준으로 마우스 커서와의 방향 벡터를 계산합니다.
        Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;

        Vector3 targetPosition = transform.position + mouseDir.normalized * dashDistance; // 방향 벡터를 정규화하여 거리만큼만 이동

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position += mouseDir.normalized * dashSpeed * Time.deltaTime; // 방향 벡터를 정규화하여 이동
            yield return null;
        }

        isDashing = false;
    }

    IEnumerator SC_Cool()
    {
        // skill.cool 값에 따라 달라짐
        float tick = 0.5f;
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
