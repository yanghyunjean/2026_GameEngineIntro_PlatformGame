using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;
    private float moveInput;
    
    //2초동안 무적아이템
    private bool isInvincible = false;
    public float invincibleTime = 2f;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Item"))
        {
            isInvincible = true;
            Invoke(nameof(ResetInvincible), 3f);
            Destroy(collision.gameObject);
            return; 
        }
        

        if (collision.CompareTag("Enemy"))
        {
            

            if (isInvincible) return;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        
        if (collision.CompareTag("Respawn"))
        {
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


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        pAni = GetComponent<Animator>();
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
