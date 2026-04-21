using System.Runtime.CompilerServices;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private bool isMovingRight = true;

    public int maxHp = 5;
    private int currentHp;
    public GameObject dropItemPrefab;

    public Outro outro; // 보스가 죽을 때 아웃트로 대사를 시작


    private void Start()
    {
        currentHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
    }


    public void TakeDamage(int Damage)
    {
        currentHp -= Damage;

        if (currentHp <= 0)
        {
            Die();
        }
    }

        void Die()
        {
        if (dropItemPrefab != null)
        {
            Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
            Instantiate(dropItemPrefab, spawnPos, Quaternion.identity);

        }
       
        Destroy(gameObject);

        }

      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);


        if (isMovingRight)
        {
            transform.localScale = new Vector3(-3.6f, 3.2f, 1);
        }
        else
        {
            transform.localScale = new Vector3(3.6f, 3.2f, 1);
        }
    }
}
