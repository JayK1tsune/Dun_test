using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonLayout;
using UnityEngine.UI;
using System;

public class SpawnRoom : MonoBehaviour
{
    DungeonSlot dungeonSlot;
    Manager manager;

    public GameObject[] rooms;

    private Button button;
    [HideInInspector]public bool hasPlayed = false;

    void Awake()
    {
        
       
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button component not found on the GameObject with SpawnRoom script.");
        }
        else
        {
            Debug.Log("Button component found successfully.");
            // Add the listener to the button
            button.onClick.AddListener(Room);
        }
        
    }
    private void Start() {
        manager = Manager.Instance;
    }
     public Button GetButton() 
    {
        return button;
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
                    //can i spawn the room as a child of the slot?
                    
                    GameObject room = Instantiate(dungeonLayoutSpawn.roomPrefab, dungeonSlot.spawnPoint.position, Quaternion.identity, dungeonSlot.spawnPoint);
                    room.name = dungeonLayoutSpawn.roomName;
                    
                }
                else
                {
                    Debug.LogError("Invalid ScriptableObject or roomPrefab not set");
                }
            }
            if (dungeonSlot.isRoomValid == true)
            { 
                hasPlayed = true;
                //Not what i wanted to do, this deletes the card from the slot
                //Destroy(dungeonSlot.transform.GetChild(0).gameObject);
            }
        }
        //spawn the waiting room and throne if null through manager
        DungeonLayoutSpawn dungeonLayoutSpawnWaiting = manager.So_waitingRoom as DungeonLayoutSpawn;
        DungeonLayoutSpawn dungeonLayoutSpawnThrone = manager.So_throne as DungeonLayoutSpawn;
        GameObject waitingroom = Instantiate(dungeonLayoutSpawnWaiting.roomPrefab, manager.waitingRoom.transform.position, Quaternion.identity, manager.waitingRoom.transform);
        waitingroom.name = dungeonLayoutSpawnWaiting.roomName;

        GameObject Throne = Instantiate(dungeonLayoutSpawnThrone.roomPrefab, manager.throne.transform.position, Quaternion.identity, manager.throne.transform);
        Throne.name = dungeonLayoutSpawnThrone.roomName;
        //make waiting room and throne played true


    }


}

