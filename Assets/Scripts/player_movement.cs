using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float defaultSpeed;
    public float sprintSpeed;
    public Rigidbody2D rb;
    public Vector2 movement;
    public KeyCode keyInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Sprint();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * defaultSpeed * Time.deltaTime);
    }

    void Sprint()
    {
        if(Input.GetKey(keyInput))
        {
            defaultSpeed = sprintSpeed;
        }
        else
        {
            defaultSpeed = 5f;
        }
    }
}
