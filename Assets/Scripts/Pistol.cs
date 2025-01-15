using Unity.VisualScripting;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;

    Vector2 mousePosition;

    public Camera cam;

    public bool ActiveAbilityTimer = false;
    public bool AbilityTimer = false;
    public bool Timer2Checker = false;

    [Header("Bullet Stats")]
    public float bulletSpeed = 15f;
    public float bulletSpeedBuff = 5f;
    public float bulletSpeedDefault = 15f;
    public float bulletDMG = 2f;

    [Header("Shooting Cooldown")]
    public float timer = 0f;
    public float cooldown = 0.5f;
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
        bulletprefab.transform.localScale = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = timer + Time.deltaTime; //NormalShooting Cooldown

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

        // when the game starts it will start the cooldown timer
        // if the ability has been activated it will set the cooldown timer to 0 and pause it

        if (timer >= cooldown)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
                timer = 0;
            }
        }
        // Shooting Cooldown

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
            bulletSpeed = bulletSpeedBuff; //stat debuff for the shooting speed to be slower
            bulletprefab.transform.localScale = new Vector3(3, 3, bulletprefab.transform.localScale.z); //ups the bullet scale

            if (timer3 >= cooldown3) //when the current ability timer has ran out
            {
                timer3 = 0;
                timer2 = 0;
                // sets both the Cooldown and Current timers to 0
                ActiveAbilityTimer = false;
                AbilityTimer = false;
                // sets both bools to false
                cooldown = defaultcooldown;
                bulletSpeed = bulletSpeedDefault;
                bulletprefab.transform.localScale = new Vector3(1, 1, bulletprefab.transform.localScale.z);
                // stats goes back to normal (aka Default)
            }
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // spawns and checks the rigidbody of the bullet within the script
        rb.AddForce(firepoint.up * bulletSpeed, ForceMode2D.Impulse); //instantly shoots the bullet with force
    }
}
