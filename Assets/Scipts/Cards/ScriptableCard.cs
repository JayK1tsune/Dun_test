using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CardData")]
public class ScriptableCard : ScriptableObject
{
    //field is used to make the variable private but still visible in the inspector (like they were public)
    [field: SerializeField] public string CardName { get; private set; }
    [field: SerializeField,TextArea] public string cardDescription { get; private set; } //text area makes the text box bigger
    [field: SerializeField] public Sprite CardImage { get; private set; }
    [field: SerializeField] public Sprite CardType { get; private set; }
    [field: SerializeField] public CardElement CardElement { get; private set; }
    [field: SerializeField] public CardAttribute CardAttribute { get; private set; }
    [field: SerializeField] public GameObject roomPrefab { get; private set; }
}


public enum CardElement
{
    Minion,
    Trap,
    Special
}
public enum CardAttribute
{
    Strength,
    Magic,
    Swift
}