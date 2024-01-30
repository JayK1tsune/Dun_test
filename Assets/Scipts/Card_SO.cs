using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]
public class Card_SO : ScriptableObject
{
    [Tooltip("Card Name")]
    public string cardName;
    [Tooltip("Card Prefab")]
    public GameObject cardPrefab;
    [Tooltip("Card Type")]
    public string cardType;
    [Tooltip("Card Colour")]    
    public Color cardColor;
}
