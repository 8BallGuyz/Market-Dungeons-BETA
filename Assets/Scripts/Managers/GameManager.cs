using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {;
        SceneManager.LoadScene("Main");
        Debug.Log("Game has been Started !");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
        Debug.Log("Settings has been Loaded !");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Main Menu has been Loaded !");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
        Debug.Log("Controls has been Loaded !");
    }
}
