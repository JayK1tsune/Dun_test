using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

public class Grabber : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler , IPointerClickHandler
{
    public Image image;
    public ScriptableObject roomPrefab;
    //private bool isClicked = false;
    //todo make a card bool to say if played or not, so button will work
    [SerializeField] public bool played = false;

    [HideInInspector] public Transform parentAfterDrag;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false; //
    }

    public void OnDrag(PointerEventData eventData)
    {
      
        Debug.Log("OnDrag");
        transform.localScale = new Vector3(1.4f, 2.0f, 1.4f);
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(parentAfterDrag);
        transform.localScale = new Vector3(0.8f, 1.2f, 0.8f);
        image.raycastTarget = true;
        
        

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        //eventData.pointerPress = gameObject;
        //make the object bigger when clicked   


        
    }
}
