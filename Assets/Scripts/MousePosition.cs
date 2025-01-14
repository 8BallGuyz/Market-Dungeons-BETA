using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Camera cam;
    Vector2 MousePos;
    public Rigidbody2D rb;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 LookDir = MousePos - rb.position;
        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
