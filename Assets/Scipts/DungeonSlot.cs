using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class DungeonSlot : MonoBehaviour, IDropHandler
{
 
    public GameObject room;
    public Transform spawnPoint;
    
    public bool isRoomValid = false;
    public bool roomplayed = false;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if(droppedObject != null)
        {
            CardMovment cardMovment = droppedObject.GetComponent<CardMovment>();
            cardMovment.parentAfterDrag = transform;
            droppedObject.transform.SetParent(transform);
            Debug.Log("Dropped object: " + droppedObject.name);
            room = droppedObject.GetComponent<Card>().CardData.roomPrefab;
        }

        
        //if(IsRoomTypeValid(droppedObject)){

        //Card card = droppedObject.GetComponent<Card>();
        //room = card.CardData.roomPrefab.GetComponent<ScriptableObject>(); // Fix: Assign the room variable with the scriptable object component of the room prefab
        //isRoomValid = droppedObject.gameObject.GetComponent<Grabber>().played = true;
        //roomplayed = true;
        //}
    }

    // void FixedUpdate()
    // {
    //     //Removing the room if the slot is empty
    //     if(gameObject.transform.childCount == 0)    
    //     {
    //         Debug.Log(gameObject.transform.childCount);
    //         DeleteData();
    //        // Debug.Log("Invalid room type");
    //     }
    // }
    // private void DeleteData(){
    //     room = null;
    //     isRoomValid = false;
    // }
}

