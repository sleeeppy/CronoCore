using UnityEngine;

public class Core : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            // �÷��̾�� �浹�ϸ� �ھ �ı��մϴ�.
            Destroy(gameObject);
        }
    }
}
