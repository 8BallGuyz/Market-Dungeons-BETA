using UnityEngine;

public class AR : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;

    public Camera cam;

    public bool ActiveAbilityTimer = false;
    public bool AbilityTimer = false;
    private bool Timer2Checker = false;

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
        timer = timer + Time.deltaTime; // Normal Shooting Cooldown

        if (ActiveAbilityTimer == false)
        {
            Timer2Checker = true;
        }
        else if (ActiveAbilityTimer == true)
        {
            timer2 = 0;
        }

        if (Timer2Checker && timer2 < cooldown2) // Increment cooldown only if timer2 is below the max
        {
            timer2 += Time.deltaTime; // Progress ability cooldown
        }

        if (timer >= cooldown)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
                timer = 0;
            }
        }

        if (timer2 >= cooldown2) // If cooldown is complete
        {
            timer2 = cooldown2; // Ensure timer2 stays at max value until right-click
            if (Input.GetKeyDown(KeyCode.Mouse1)) // Right-click to activate ability
            {
                timer2 = 0; // Reset cooldown timer
                ActiveAbilityTimer = true;
                AbilityTimer = true;
            }
            //when the 2nd timer is equal or higher than the ability cooldown AND the right mouse has been clicked
            //sets the 2nd timer back to 0 and activates the Current Ability timer and the Ability Timer 
        }

        if (ActiveAbilityTimer) //when this is true it will start the Active Ability Timer
        {
            timer3 = timer3 + Time.deltaTime; //timer for the current ability
            cooldown = buffcooldown; //stat debuff for the shooting cooldown to be slower

            if (timer3 >= cooldown3) //when the current ability timer has ran out
            {
                timer3 = 0;
                timer2 = 0;
                // sets both the Cooldown and Current timers to 0
                ActiveAbilityTimer = false;
                AbilityTimer = false;
                // sets both bools to false
                cooldown = defaultcooldown;
                // stats goes back to normal (aka Default)
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
