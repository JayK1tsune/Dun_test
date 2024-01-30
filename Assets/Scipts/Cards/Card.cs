using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardUI))] // This will add the CardUI component if it is not already present
[RequireComponent(typeof(CardMovment))] // This will add the CardMovment component if it is not already present
public class Card : MonoBehaviour
{
    [field: SerializeField] public ScriptableCard CardData { get; private set; }

    public void SetCardData(ScriptableCard cardData)
    {
        CardData = cardData;
        GetComponent<CardUI>().SetCardUI();
    }
}
