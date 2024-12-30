using UnityEngine;

public class camera_script : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraPosition = new Vector3(0f,0f,-10f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraPosition;
    }
}
