using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static Deck instance{get; private set;}  
    //reference to the deck
    [SerializeField] private CardCollection _playerDeck;
    [SerializeField] private Card _cardPrefab; //reference to the card prefab that we will make a copy of with the different card data
    [SerializeField] private Canvas _cardCanvas; //reference to the canvas that the card will be instantiated on
    private List<Card> _deckpile = new();
    private List<Card> _discardpile = new();


    public List<Card> HandCards {get; private set;} = new();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InstantiateDeck();
    }

    private void InstantiateDeck()
    {
        for(int i = 0; i < _playerDeck.CardsinCollection.Count; i++)
        {
            Card card = Instantiate(_cardPrefab, _cardCanvas.transform); //instantiate the card prefab
            card.SetCardData(_playerDeck.CardsinCollection[i]); //set the card data
            _deckpile.Add(card); //add the card to the deck pile
            card.gameObject.SetActive(false); //set the card to inactive

        }   
    }

    //shuffle the deck
    //use Fisher-Yates shuffle algorithm
    public void ShuffleDeck()
    {
        for(int i = _deckpile.Count -1; i > 0; i--)
        {
            int j = Random.Range(0, i+1);
            var temp = _deckpile[i];
            _deckpile[i] = _deckpile[j];
            _deckpile[j] = temp;
        }
    }

    //draw a card from the deck
    public void DrawCard(int amount = 5)
    {
        for (int i=0; i < amount; i++)
        {
            if(_deckpile.Count <= 0)
            {
                _discardpile = _deckpile;
                _discardpile.Clear();
                ShuffleDeck();
            }
            if (_deckpile.Count > 0)
            {
                HandCards.Add(_deckpile[0]);
                _deckpile[0].gameObject.SetActive(true);
                _deckpile.RemoveAt(0);
            }

        }
    }

    //discard a card from the hand
    public void DiscardCard(Card card)
    {
        if(HandCards.Contains(card))
        {
            HandCards.Remove(card);
            _discardpile.Add(card);
            card.gameObject.SetActive(false);
        }
    }
}
