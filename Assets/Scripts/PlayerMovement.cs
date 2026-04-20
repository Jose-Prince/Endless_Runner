using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jump;
    [SerializeField] Transform firePoint;
    [SerializeField] float burstDelay = 0.1f;

    [SerializeField] Vector2 rightOffset = new Vector2(1f, 0f);
    [SerializeField] Vector2 upOffset = new Vector2(0f, 1f);
    [SerializeField] Vector2 diagOffset = new Vector2(0.7f, 0.7f);

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
        UpdateFirePoint();

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
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);
    }

    void UpdateFirePoint()
    {
        bool up = Input.GetKey(KeyCode.W);
        bool right = Input.GetKey(KeyCode.D);

        if (up && right)
        {
            firePoint.localPosition = diagOffset;
            firePoint.localRotation = Quaternion.Euler(0, 0, 22.5f);
        }
        else if (up)
        {
            firePoint.localPosition = upOffset;
            firePoint.localRotation = Quaternion.Euler(0, 0, 45f);
        }
        else
        {
            firePoint.localPosition = rightOffset;
            firePoint.localRotation = Quaternion.Euler(0, 0, 0f);
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
