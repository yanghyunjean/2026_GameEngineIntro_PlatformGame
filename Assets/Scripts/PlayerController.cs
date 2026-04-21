using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float jumpForce = 4.9f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;
    private float moveInput;
    
    //2초동안 무적아이템
    private bool isInvincible = false;
    public float invincibleTime = 2f;

    //2초동안 속도 증가 아이템
    private bool isDash = false;
    public float DashTime = 2f;

    private bool isJump = false;
    public float jumpTime = 5f;
    private float originalSpeed;
    private float originalJumpForce;

    public Outro outro;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Item"))
        {
            isInvincible = true;
            Invoke(nameof(ResetInvincible), 3f);
            Destroy(collision.gameObject);
            return; 
        }

        if (collision.CompareTag("Item_fast"))
        {
            isDash = true;
            moveSpeed = originalSpeed * 2f; // 속도 증가
            Invoke(nameof(ResetDash), 3f);
            Destroy(collision.gameObject);
            return;
        }

        if (collision.CompareTag("Item_Jump"))
        {
            isJump = true;
            jumpForce = originalJumpForce * 4f; // 점프력 증가
            Invoke(nameof(ResetJump), 3f);
            Destroy(collision.gameObject);
            return;
        }

        if (collision.CompareTag("Item_Memory"))
        {

            Debug.Log("메모리 아이템 먹음");
            if (outro != null)
            {
                Debug.Log("아웃트로 실행");
                outro.PlayOutro();
            }

            Destroy(collision.gameObject);
            return;
        }


        if (collision.CompareTag("Enemy"))
        {
            if (rb.linearVelocity.y < 0)
            {
                BossController boss = collision.gameObject.GetComponent<BossController>();

                if (boss != null)
                {
                    if(isJump)
                    {
                        boss.TakeDamage(999);
                    } 
                    else
                    {
                        boss.TakeDamage(1);
                    }
                }

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 0.7f);
            }
            else
            {
                // 옆이나 위에서 닿으면 죽음
                if (isInvincible) return;

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        
        if (collision.CompareTag("Respawn"))
        {
            if (isInvincible) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        
        Door door = collision.GetComponent<Door>();
        if (door != null)
        {
            SceneManager.LoadScene(door.sceneName);
            return;
        }
    }

    void ResetInvincible()
    {
        isInvincible = false;
    }

    void ResetDash()
    {
        isDash = false;
        moveSpeed = originalSpeed; // 원래 속도로 복원
    }

    void ResetJump()
    {
        isJump = false;
        jumpForce = originalJumpForce; // 원래 점프력으로 복원
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        pAni = GetComponent<Animator>();

           originalSpeed = moveSpeed;   
        originalJumpForce = jumpForce;


    }

    private void Update()
    {
        

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1 , 1);
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;

        pAni.SetTrigger("DashAction");
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
          
        }
    }
    

}
