using UnityEngine;

public class weapon_switcher : MonoBehaviour
{
    public MonoBehaviour AR;
    public MonoBehaviour Pistol;
    public KeyCode KeyBindAR;
    public KeyCode KeyBindSniper;

    // Array to hold the scripts
    private MonoBehaviour[] scripts;

    // Index of the currently active script
    private int currentIndex = 0;

    void Start()
    {
        // Populate the scripts array
        scripts = new MonoBehaviour[] { Pistol, AR };

        // Ensure only the first script is active initially
        ActivateScript(currentIndex);
    }

    void Update()
    {
        // Listen for key presses and switch scripts accordingly
        if (Input.GetKeyDown(KeyBindAR))
        {
            SwitchToScript(0);  // Switch to scriptA
        }
        else if (Input.GetKeyDown(KeyBindSniper))
        {
            SwitchToScript(1);  // Switch to scriptB
        }
    }

    void SwitchToScript(int index)
    {
        if (index >= 0 && index < scripts.Length)
        {
            currentIndex = index;
            ActivateScript(currentIndex);
        }
    }

    void ActivateScript(int index)
    {
        // Disable all scripts
        foreach (var script in scripts)
        {
            if (script != null)
            {
                script.enabled = false;
            }
        }

        // Enable the selected script
        if (scripts[index] != null)
        {
            scripts[index].enabled = true;
            Debug.Log($"Activated: {scripts[index].GetType().Name}");
        }
        else
        {
            Debug.LogWarning($"Script at index {index} is not assigned.");
        }
    }
}
