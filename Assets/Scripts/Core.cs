using UnityEngine;

public class Core : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            // 플레이어와 충돌하면 코어를 파괴합니다.
            Destroy(gameObject);
        }
    }
}
