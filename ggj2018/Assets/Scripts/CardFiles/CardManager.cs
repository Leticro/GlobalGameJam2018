using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public int handSize = 8;
    public CardList cardList;

    public Deck deckPrefab;

    private Deck deck;
    private List<Card> hand;    // virtual hand from deck
    private List<Card> inGameHand; // hand in the scene

    private Canvas canvas;

    private int cardX = -160;
    private int cardY = 80;

    // Use this for initialization
    void Start() {

        deck = Instantiate(deckPrefab);

        canvas = FindObjectOfType<Canvas>();
        print("test");
        print(canvas);

        //DontDestroyOnLoad(deck);
        //DontDestroyOnLoad(this.gameObject);

        drawHand();
    }

    public void drawHand()
    {
        hand = new List<Card>();
        inGameHand = new List<Card>();

        int x = cardX;
        int y = cardY;
        while (hand.Count < handSize && deck.Cards.Count > 0)
        {
            Card card = deck.drawFromDeck();
            hand.Add(card);
            Card inGameCard = Instantiate(card, canvas.transform);
            inGameHand.Add(inGameCard);
            if (hand.Count == 5)
            {
                x = cardX;
                y = 0;
            }
            inGameCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            x += 60;
            print(inGameCard.GetComponent<RectTransform>().anchoredPosition);
        }

        //for(int i = 0; i < hand.Count; i++)
        //{
        //    inGameHand Instantiate
        //}
        
    }

    // user has chosen a card
    public void continueWithChoice(Card card)
    {


        foreach (Card c in inGameHand)
        {
            Destroy(c);
        }
    }


    //void getCardPack(int count)
    //{
    //    while (count > 0)
    //    {
    //        if(deck.getCards().Count < deckSize)
    //        {
    //            removeFromDeck();
    //        }

    //        deck.getCards().Add(cardList.getRandomCard());
    //    }
    //}

    //void removeFromDeck()
    //{
    //    //display deck here to choose what to remove
    //    deck.getCards().RemoveAt(0);
    //}
}
