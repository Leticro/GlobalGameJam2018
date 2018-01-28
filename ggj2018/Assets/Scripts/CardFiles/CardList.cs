using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList: MonoBehaviour {
    
    public List<Card> cards;

    public Card getRandomCard()
    {
        int random = Random.Range(0, cards.Count);
        return cards[random];
    }
}
