using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int deckSize = 24;
    public int startSize = 12;
    public List<Card> Cards { get; set; }
    public CardList cardList;

    void Awake()
    {
        // initialize deck
        Cards = new List<Card>();
        for (int i = startSize; i > 0; i--)
        {
            Cards.Add(cardList.getRandomCard());
        }
    }

    public Card drawFromDeck()
    {
        int randomIndex = Random.Range(0, Cards.Count);
        Card card = Cards[randomIndex];
        Cards.RemoveAt(randomIndex);
        return card;
    }
}
