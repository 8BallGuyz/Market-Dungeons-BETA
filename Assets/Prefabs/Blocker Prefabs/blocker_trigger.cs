using UnityEngine;

public class blocker_trigger : MonoBehaviour
{
    public bool IsActivated { get; private set; } = false; // Property to check if trigger is activated

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player") && !IsActivated)
        {
            IsActivated = true; // Mark as activated
            // Optionally, notify the connector directly
            // connector.TriggerActivated();
        }
    }
}

