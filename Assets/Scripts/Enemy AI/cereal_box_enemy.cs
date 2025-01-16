using System.Threading;
using UnityEngine;

public class cereal_box_enemy : MonoBehaviour
{
    public float Speed;
    private GameObject Target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("player");
    }

    // FixedUpdate is called once per frame, at a fixed time interval
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }
}
