using UnityEngine;

public class trigger_connector : MonoBehaviour
{
    public GameObject[] Blockers; // Array of blockers to spawn
    public GameObject[] Triggers; // Array of trigger objects
    public float delay = 0.5f; // Delay before spawning blockers

    private bool hasTriggered = false; // Flag to ensure blockers are spawned only once

    void Update()
    {
        if (hasTriggered)
            return;

        // Check if any trigger has been activated
        foreach (var trigger in Triggers)
        {
            if (trigger.GetComponent<blocker_trigger>().IsActivated)
            {
                // Spawn corresponding blockers
                for (int i = 0; i < Blockers.Length; i++)
                {
                    Instantiate(Blockers[i], Triggers[i].transform.position, Triggers[i].transform.rotation);
                }
                hasTriggered = true;
                break;
            }
        }
    }
}


