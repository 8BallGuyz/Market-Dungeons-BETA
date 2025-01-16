using UnityEngine;

public class apple_enemy : MonoBehaviour
{
    public float Speed;
    public float fireSpeed;
    public GameObject bulletprefab;
    public Transform enemyFirepoint;
    private GameObject Target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Shoot", 2f, 2f);
        Target = GameObject.FindGameObjectWithTag("player");
    }

    // FixedUpdate is called once per frame, at a fixed time interval
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }
    void Shoot()
    {
        // Spawn a bullet at the firepoint's position and rotation
        GameObject apple_bullet = Instantiate(bulletprefab, enemyFirepoint.position, enemyFirepoint.rotation);

        // Calculate the direction from the firepoint to the player
        Vector2 directionToPlayer = (Target.transform.position - enemyFirepoint.position).normalized;

        Rigidbody2D rb = apple_bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(directionToPlayer * fireSpeed, ForceMode2D.Impulse);
    }
}

