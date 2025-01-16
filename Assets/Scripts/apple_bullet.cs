using UnityEngine;

public class apple_bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 targetDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Find the player's current position
        GameObject player = GameObject.FindGameObjectWithTag("player");

        // Calculate the direction to the player
        if (player != null)
        {
            Vector2 playerPosition = player.transform.position;
            targetDirection = (playerPosition - rb.position).normalized;

            // Rotate the bullet to face the player
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            // Apply an impulse force to the bullet in the direction of the player
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall") || collision.CompareTag("deco"))
        {
            Destroy(gameObject);
        }
    }

}
