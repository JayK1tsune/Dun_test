using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Collection")]
public class CardCollection : ScriptableObject
{
    [field: SerializeField]public List<ScriptableCard> CardsinCollection{get; private set;}

    public void AddCard(ScriptableCard card)
    {
        CardsinCollection.Add(card);
    }
    public void RemoveCard(ScriptableCard card)
    {
        if(CardsinCollection.Contains(card))
        {
            CardsinCollection.Remove(card);
        }
        else
        {
            Debug.LogWarning("Card not found");
        }
    }

}
