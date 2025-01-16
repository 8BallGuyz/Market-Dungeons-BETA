using UnityEngine;
using UnityEngine.UI;
public class ability_timer : MonoBehaviour
{
    public Pistol pistol;
    public AR AR;
    public Text PistolCooldown;
    public Text ARCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PistolAbilityCooldown();
        ARAbilityCooldown();
    }

    void PistolAbilityCooldown()
    {
        if (pistol.ActiveAbilityTimer) // If the ability is active
        {
            PistolCooldown.text = Mathf.FloorToInt(pistol.cooldown3 - pistol.timer3).ToString();
            // Displays remaining ability duration
        }
        else // If the ability is not active
        {
            PistolCooldown.text = Mathf.FloorToInt(pistol.cooldown2 - pistol.timer2).ToString();
            // Displays remaining cooldown time for the ability
        }
    }

    void ARAbilityCooldown()
    {
        if (AR.ActiveAbilityTimer) // If the ability is active
        {
            ARCooldown.text = Mathf.FloorToInt(AR.cooldown3 - AR.timer3).ToString();
            // Displays remaining ability duration
        }
        else // If the ability is not active
        {
            ARCooldown.text = Mathf.FloorToInt(AR.cooldown2 - AR.timer2).ToString();
            // Displays remaining cooldown time for the ability
        }
    }
}
