using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jump;
    [SerializeField] Transform firePoint;
    [SerializeField] float burstDelay = 0.1f;

    private bool isShooting = false;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDropping;
    private Collider2D currentGround;
    private Collider2D lastGround;
    private BulletPool pool;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        pool = GetComponent<BulletPool>();
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

        if (Input.GetKeyDown(KeyCode.J) && isGrounded && !isShooting)
        {
            StartCoroutine(ShootBurst());
        }
    }

    IEnumerator ShootBurst()
    {
        isShooting = true;

        for (int i = 0; i < 3; i++)
        {
            Shoot();
            yield return new WaitForSeconds(burstDelay);
        }    

        isShooting = false;
    }

    void Shoot()
    {
        GameObject bullet = pool.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.SetActive(true);
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
