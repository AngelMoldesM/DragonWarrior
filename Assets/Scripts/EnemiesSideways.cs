using UnityEngine;

public class EnemiesSideways : MonoBehaviour
{   
    [SerializeField] private float movementDistance;
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= leftEdge)
            {
                movingLeft = false;
            }
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= rightEdge)
            {
                movingLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthController>().TakeDamage(damage);
        }
    }
}
