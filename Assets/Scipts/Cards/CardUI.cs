using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    private Card card;

    [Header("UI Elements")]
    [SerializeField] private Image cardImage;
    [SerializeField] private Image typeFrame;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardType;
    [SerializeField] private TextMeshProUGUI cardDescription;
    [SerializeField] private Image type;
    [SerializeField] private Image typeImage;

    [Header("Sprite Assets")]
    [SerializeField] private Sprite _strMinion;
    [SerializeField] private Sprite _magMinion;
    [SerializeField] private Sprite _sftMinion;
    [SerializeField] private Sprite strengthIcon;
    [SerializeField] private Sprite magicIcon;
    [SerializeField] private Sprite swiftIcon;

    //add more sprites here backgrounds ect
    private readonly string EFFECTTYPE_Minion = "Minion";
    private readonly string EFFECTTYPE_Trap = "Trap";
    private readonly string EFFECTTYPE_Special = "Special";

    private void Awake()
    {
        card = GetComponent<Card>();
        SetCardUI();
        SetCardType();
        SetCardAttribute();
        SetCardImage();
    }

    void OnValidate()
    {
        Awake();
    }

    public void SetCardUI()
    {
        if (card.CardData != null && card.CardData != null)
        {
            SetCardText();
        }
    }
    private void SetCardText()
    {
        cardName.text = card.CardData.CardName;
        cardType.text = card.CardData.CardElement.ToString();
        cardDescription.text = card.CardData.cardDescription;

    }
    private void SetCardType()
    {
        switch (card.CardData.CardElement) // minon / trap / special
        {
            case CardElement.Minion:
                
                type.sprite = _strMinion;
                break;
            case CardElement.Trap:
                
                type.sprite = _magMinion;
                break;
            case CardElement.Special:
                
                type.sprite = _sftMinion;
                break;
        }
    }

    private void SetCardAttribute()
    {
        switch (card.CardData.CardAttribute) // strength / magic / swift
        {
            case CardAttribute.Strength:
                typeImage.sprite = strengthIcon;
                break;
            case CardAttribute.Magic:
                typeImage.sprite = magicIcon;
                break;
            case CardAttribute.Swift:
                typeImage.sprite = swiftIcon;
                break;
        }
    }

    private void SetCardImage()
    {
        cardImage.sprite = card.CardData.CardImage;
    }

}
