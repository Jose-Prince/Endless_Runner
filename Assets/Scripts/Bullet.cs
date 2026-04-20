using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private float timer;

    void OnEnable()
    {
        timer = 0;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer > 2f)
        {
            gameObject.SetActive(false);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            gameObject.SetActive(false);
    }
}
