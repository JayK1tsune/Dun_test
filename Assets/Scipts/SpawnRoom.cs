using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonLayout;
using UnityEngine.UI;
using System;

public class SpawnRoom : MonoBehaviour
{
    DungeonSlot dungeonSlot;
    public GameObject[] rooms;
    [SerializeField] private GameObject defaultRoom;
    [SerializeField] private GameObject waitingRoom;
    [SerializeField] private GameObject bossRoom;
    [SerializeField] private Transform waitingRoomSpawnPoint;
    [SerializeField] private Transform bossRoomSpawnPoint;

    private Button button;
    [HideInInspector] public bool hasPlayed = false;

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
            hasPlayed = true;
            dungeonSlot = r.GetComponent<DungeonSlot>();
            if (dungeonSlot.room != null)
            {
                //spawn room that has the atatched prefab on the card 
                Instantiate(dungeonSlot.room, dungeonSlot.spawnPoint.position, Quaternion.identity, dungeonSlot.spawnPoint);

            }
            else
            {
                Instantiate(defaultRoom, dungeonSlot.spawnPoint.position, Quaternion.identity, dungeonSlot.spawnPoint);
                hasPlayed = true;
                Debug.LogError("Invalid ScriptableObject or roomPrefab not set");
                if(bossRoomSpawnPoint.childCount == 0 || waitingRoomSpawnPoint.childCount == 0)
                {
                    Instantiate(waitingRoom, waitingRoomSpawnPoint.position, Quaternion.identity, waitingRoomSpawnPoint);
                    Instantiate(bossRoom, bossRoomSpawnPoint.position, Quaternion.identity, bossRoomSpawnPoint);
                }
   
            }
        }

    }






}

