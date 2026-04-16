using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.left * speed;
    }
}
