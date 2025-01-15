using UnityEngine;

public class AR : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;

    public Camera cam;

    public bool ActiveAbilityTimer = false;

    [Header("Bullet Stats")]
    public float bulletSpeed;
    public float bulletDMG;

    Vector2 mousePosition;

    [Header("Shooting Cooldown")]
    public float timer = 0f;
    public float cooldown = 0.15f;
    public float buffcooldown = 0.1f;
    public float defaultcooldown = 0.15f;

    [Header("Ability Cooldown")]
    public float timer2 = 0f;
    public float cooldown2 = 30f;

    [Header("Ability Usage Time")]
    public float timer3 = 0f;
    public float cooldown3 = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        timer2 = timer2 + Time.deltaTime;

        if (timer >= cooldown)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
                timer = 0;
            }
        }

        if(timer2 >= cooldown2)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                timer2 = 0;
                ActiveAbilityTimer = true;
            }
        }

        if (ActiveAbilityTimer)
        {
            timer3 = timer3 + Time.deltaTime;
            cooldown = buffcooldown;

            if (timer3 >= cooldown3)
            {
                timer3 = 0;
                timer2 = 0;
                ActiveAbilityTimer = false;
                cooldown = defaultcooldown;
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
