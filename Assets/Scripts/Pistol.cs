using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;

    public float bulletSpeed;
    public float bulletDMG;

    Vector2 mousePosition;

    public Camera cam;

    public float timer = 0;
    public float cooldown = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;

        if (timer >= cooldown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
                timer = 0;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
