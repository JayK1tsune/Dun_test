using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovment : MonoBehaviour , IEndDragHandler, IBeginDragHandler , IDragHandler
{
    private bool _isbeingDragged;
    private Canvas _cardCanvas;
    private RectTransform _rectTransform;
    private Card card;
    private readonly string CANVAS_TAG = "CardCanvas";


    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _cardCanvas = GameObject.FindGameObjectWithTag(CANVAS_TAG).GetComponent<Canvas>();
        card = GetComponent<Card>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _isbeingDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += (eventData.delta / _cardCanvas.scaleFactor);
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        _isbeingDragged = false;
        //discard card when dropped
        //Deck.instance.DiscardCard(card);
    }
}
