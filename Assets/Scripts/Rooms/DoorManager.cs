using UnityEngine;
using UnityEngine.Rendering;

public class DoorManager : MonoBehaviour
{
    private door_script[] doorsInRoom;

    void Start()
    {
        // Find all the door_script components within this room
        doorsInRoom = GetComponentsInChildren<door_script>();
    }

    // This method will close all doors in the room
    public void CloseAllDoors()
    {
        foreach (door_script door in doorsInRoom)
        {
            door.CloseDoor(); // Call the CloseDoor() method for each door
        }
    }
}
