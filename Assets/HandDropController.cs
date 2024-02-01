using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandDropController : MonoBehaviour , IDropHandler
{


    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        
        if(eventData.pointerDrag != null)
        {
            CardMovment cardMovment = droppedObject.GetComponent<CardMovment>();
            cardMovment.parentAfterDrag = transform;
            droppedObject.transform.SetParent(transform);
            Debug.Log("Dropped object: " + droppedObject.name);
        }
    }
}

