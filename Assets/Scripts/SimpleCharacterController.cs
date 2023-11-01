using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting.APIUpdating;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    Camera characterCamera;

    public GameObject bulletPrefab;

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))

        {   // 플레이어의 좌표와 겹치게 총알이 소환될 경우 플레이어에게 데미지를 줄 수 있기 때문에 조금 앞에서 소환함
            Vector3 firePos = transform.position + animator.transform.forward + new Vector3(0f, 0.5f, 0f);
            // 총알을 firePos에 생성, 생성된 총알 객체를 반환해 Bullet에 저장
            var bullet = Instantiate(bulletPrefab, firePos, Quaternion.identity).GetComponent<Bullet>();
            // Bullet 스크립트의 Fire 메서드 호출, 전방으로 총알이 나감
            bullet.Fire(animator.transform.forward);
        }
    }

    private void Awake()
    {   
        // 메인 케릭터의 자식 요소인 메인 카메라를 불러옴
        characterCamera = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        Move();
        Zoom();
    }

    public void LookMouseCursor()
    {     
        Ray ray = characterCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if (Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            animator.transform.forward = mouseDir;
        }
    }
    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveX, 0f, moveZ);
        // 무브 벡터의 길이가 0이 아니면 키 입력이 들어오는 것으로 판정
        bool isMove = moveVector.magnitude > 0;
        // 애니메이터의 isMove의 값을 무브 벡터의 길이에 따라서 바뀌도록 함
        animator.SetBool("isMove", isMove);
        LookMouseCursor();
        Fire();
        // 유니티 엔진 1 단위는 1미터
        transform.Translate(new Vector3(moveX, 0f, moveZ).normalized * Time.deltaTime * 5f);
    }

    public void Zoom()
    {
        // 마우스 스크롤 값을 받아옴
        var scroll = Input.mouseScrollDelta;
        // 시야 왜곡을 방지하기 위해서 30~70 사이의 값으로 fieldOfView를 고정해줌
        characterCamera.fieldOfView = Mathf.Clamp(characterCamera.fieldOfView - scroll.y, 30f, 70f);
    }
}