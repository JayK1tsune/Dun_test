using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovment : MonoBehaviour , IEndDragHandler, IBeginDragHandler , IDragHandler
{
    private bool _isbeingDragged;
    public Image image;
    private Canvas _cardCanvas;
    private RectTransform _rectTransform;
    private Card card;
    private readonly string CANVAS_TAG = "CardCanvas";
    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _cardCanvas = GameObject.FindGameObjectWithTag(CANVAS_TAG).GetComponent<Canvas>();
        card = GetComponent<Card>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //_isbeingDragged = true;
        parentAfterDrag = transform.parent;

        Image[] images = GetComponentsInChildren<Image>();
        foreach(Image childImage in images)
        {
            childImage.raycastTarget = false;
        }
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        //_isbeingDragged = false;
        transform.SetParent(parentAfterDrag);
        Debug.Log("Parent after drag: " + parentAfterDrag);
        image.raycastTarget = true;
        //discard card when dropped
        //Deck.instance.DiscardCard(card);
    }
}
