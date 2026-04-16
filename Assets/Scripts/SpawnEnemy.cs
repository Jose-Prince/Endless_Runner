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

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 6)
        {
            Destroy(gameObject);
        }
        
        rb.linearVelocity = Vector2.left * (speed + gm.speedMultiplier);
    }
}
