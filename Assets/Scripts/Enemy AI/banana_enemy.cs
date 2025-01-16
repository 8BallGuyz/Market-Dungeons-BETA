using System.Threading;
using UnityEngine;

public class banana_enemy : MonoBehaviour
{
    public float Speed;
    public float speedBuff;
    public float defaultSpeed;
    private GameObject Target;

    public float timer = 0f;
    public float timer2 = 0f;
    public float cooldown = 5f;
    public float chargeActive = 5f;

    private bool Timer1 = true;
    private bool Timer2 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("player");
    }

    // FixedUpdate is called once per frame, at a fixed time interval
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);

        Charge();
    }

    void Charge()
    {
        if (Timer1 == true)
        {
            timer = timer + Time.deltaTime;
        }
        // NORMAL MODE

        if (timer >= chargeActive)
        {
            Speed = speedBuff;
            timer = 0f;
            Timer1 = false;
            Timer2 = true;
        }

        if (Timer2 == true)
        {
            timer2 = timer2 + Time.deltaTime;
        }
        // CHARGE MODE

        if (timer2 >= cooldown)
        {
            Speed = defaultSpeed;
            Timer2 = false;
            Timer1 = true;
            timer2 = 0f;
        }
        // RESET
    }
}
