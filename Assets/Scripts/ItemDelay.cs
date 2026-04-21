using UnityEngine;

public class ItemDelay : MonoBehaviour
{
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false; // 처음엔 못 먹음
        Invoke(nameof(EnableCollider), 0.7f); // 0.7초 후 활성화
    }

    void EnableCollider()
    {
        col.enabled = true;
    }
}
