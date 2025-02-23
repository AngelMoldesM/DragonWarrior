using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] private float healthAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthController>().AddHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
