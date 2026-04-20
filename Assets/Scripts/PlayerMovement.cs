using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jump;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDropping;
    private Collider2D currentGround;
    private Collider2D lastGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Start()
    {
    
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }    

        if (Input.GetKeyDown(KeyCode.S) && isGrounded && !isDropping)
        {
            currentGround.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (lastGround != null)
                lastGround.enabled = true;
                
            currentGround = collision.collider;
            currentGround.enabled = true;
            isGrounded = true;
        }     
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            lastGround = currentGround;
            isGrounded = false;
            currentGround = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
