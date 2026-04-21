using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gm;
    private float timer;
    private GameObject player;

    [SerializeField] float speed;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 6)
        {
            gameObject.SetActive(false);
        }
        
        rb.linearVelocity = Vector2.left * (speed + gm.speedMultiplier);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
            gameObject.SetActive(false);
    }
}
