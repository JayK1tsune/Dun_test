using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonLayout;
using UnityEngine.UI;

public class SpawnRoom : MonoBehaviour
{
    DungeonSlot dungeonSlot;

    public GameObject[] rooms;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Room);
    }

    void Update()
    {
        rooms = GameObject.FindGameObjectsWithTag("CardDunSlots");
    }

    void Room()
    {
        foreach (GameObject r in rooms)
        {
            dungeonSlot = r.GetComponent<DungeonSlot>();
            if (dungeonSlot.room != null && dungeonSlot.isRoomValid == true)
            {
                Debug.Log("Room is not null");

                
                DungeonLayoutSpawn dungeonLayoutSpawn = dungeonSlot.room as DungeonLayoutSpawn;
                if (dungeonLayoutSpawn != null && dungeonLayoutSpawn.roomPrefab != null)
                {
                    // Instantiate the room prefab from the ScriptableObject
                    GameObject room = Instantiate(dungeonLayoutSpawn.roomPrefab, dungeonSlot.spawnPoint.position, Quaternion.identity);
                    room.name = dungeonLayoutSpawn.roomName;
                }
                else
                {
                    Debug.LogError("Invalid ScriptableObject or roomPrefab not set");
                }
            }
            if (dungeonSlot.isRoomValid == true)
            { //Not what i wanted to do, this deletes the card from the slot
                //Destroy(dungeonSlot.transform.GetChild(0).gameObject);
            }
        }
    }
}
