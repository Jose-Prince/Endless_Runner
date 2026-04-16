using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gm;

    [SerializeField] float speed;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.left * (speed + gm.speedMultiplier);
    }
}
