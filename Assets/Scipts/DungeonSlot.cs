using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class DungeonSlot : MonoBehaviour, IDropHandler
{
    public string roomName;
    public ScriptableObject room;
    public Transform spawnPoint;
    public bool isRoomValid = false;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if(IsRoomTypeValid(droppedObject)){
            Grabber grabber = droppedObject.GetComponent<Grabber>();
            grabber.parentAfterDrag = transform;
            room = grabber.roomPrefab; 
            //todo, is this the best way to do this?
            isRoomValid = droppedObject.gameObject.GetComponent<Grabber>().played = true; 
        }
    }

    void FixedUpdate()
    {
        //Removing the room if the slot is empty
        if(gameObject.transform.childCount == 0)    
        {
            Debug.Log(gameObject.transform.childCount);
            DeleteData();
            Debug.Log("Invalid room type");
        }
    }
    private void DeleteData(){
        room = null;
        isRoomValid = false;
    }


    //this may not be needed going forward, was a test to see if the room type was valid
    private bool IsRoomTypeValid(GameObject droppedObject)
    {
        //check tag
        return droppedObject.CompareTag(roomName);
    }
}

