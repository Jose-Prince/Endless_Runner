using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gm;
    private float timer;

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
}
