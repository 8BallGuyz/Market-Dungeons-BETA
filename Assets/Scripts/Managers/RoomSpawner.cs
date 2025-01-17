using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public float roomDirection;
    //1 = bottom floors
    //2 = top floors
    //3 = left floors
    //4 = right floors

    private bool spawned = false;
    public RoomManager roomManager;
    private int RandomSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomManager = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomManager>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            if (roomDirection == 1)
            {
                RandomSpawn = Random.Range(0, roomManager.bottomRoom.Length);
                Instantiate(roomManager.bottomRoom[RandomSpawn], transform.position, Quaternion.identity);
                Debug.Log("Bottom Room spawned");
            }
            else if (roomDirection == 2)
            {
                RandomSpawn = Random.Range(0, roomManager.topRoom.Length);
                Instantiate(roomManager.topRoom[RandomSpawn], transform.position, Quaternion.identity);
                Debug.Log("Top Room spawned");
            }
            else if (roomDirection == 3)
            {
                RandomSpawn = Random.Range(0, roomManager.leftRoom.Length);
                Instantiate(roomManager.leftRoom[RandomSpawn], transform.position, Quaternion.identity);
                Debug.Log("Left Room spawned");
            }
            else if (roomDirection == 4)
            {
                RandomSpawn = Random.Range(0, roomManager.rightRoom.Length);
                Instantiate(roomManager.rightRoom[RandomSpawn], transform.position, Quaternion.identity);
                Debug.Log("Right Room spawned");
            }

            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>() && other.GetComponent<RoomSpawner>().spawned == true)
            {
                Debug.Log("Room succefully destroyed");
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("SpawnCollider"))
        {
            {
                Debug.Log("Room succefully destroyed");
                Destroy(gameObject);
            }
        }
    }
}
