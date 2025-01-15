using UnityEngine;
using UnityEngine.UI;
public class ability_timer : MonoBehaviour
{
    public Pistol pistol;
    public Text Cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pistol.ActiveAbilityTimer) // If the ability is active
        {
            Cooldown.text = Mathf.FloorToInt(pistol.cooldown3 - pistol.timer3).ToString();
            // Displays remaining ability duration
        }
        else // If the ability is not active
        {
            Cooldown.text = Mathf.FloorToInt(pistol.cooldown2 - pistol.timer2).ToString();
            // Displays remaining cooldown time for the ability
        }
    }
}
