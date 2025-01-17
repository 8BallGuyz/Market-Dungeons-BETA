using Unity.VisualScripting;
using UnityEngine;

public class door_script : MonoBehaviour
{
    public bool isOpen = true;
    private bool Timer = false;
    public float timer = 0f;
    public float delay = 1f;
    public Collider2D cd;
    public SpriteRenderer sr;

    public GameObject doors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cd = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        doors = GameObject.FindGameObjectWithTag("door");
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer == true)
        {
            timer = timer + Time.deltaTime;
        }
        if (timer >= delay)
        {
            CloseDoor();
        }

        if(isOpen == true)
        {
            doors.GetComponent<Collider2D>().enabled = false;
            cd.isTrigger = true;
            sr.color = Color.black;
        }
        else
        {
            doors.GetComponent<Collider2D>().enabled = true;
            sr.color = Color.red;
            cd.isTrigger = false;
        }
    }
    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            Debug.Log("Player has passed the door !");
            Timer = true;
        }
    }
}
