using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {

    public int handSize = 8;
    public CardList cardList;

    public Deck deckPrefab;

    private Deck deck;
    private List<Card> hand;    // virtual hand from deck
    private List<Card> inGameHand; // hand in the scene

    private Canvas canvas;
    public ChoiceTree choiceTree;

    // card start coordinates
    private int cardX = -160;
    private int cardY = 100;
    //card spacing
    private int cardXspace = 80;
    private int cardYspace = 120;

    // Instructions
    public Text instructions;

    public RouteChoice RouteChoice { get; set; }

    // Use this for initialization
    void Start() {

        deck = Instantiate(deckPrefab);

        canvas = this.transform.GetChild(0).GetComponent<Canvas>();

        DontDestroyOnLoad(deck);
        DontDestroyOnLoad(this.gameObject);

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
                y -= cardYspace;
            }
            inGameCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            x += cardXspace;
        }
        
    }

    // user has chosen a card
    public void continueWithChoice(Card card)
    {
        CardEmotion resultEmotion = choiceTree.calculateViolence(card);
        CardElement resultElement = choiceTree.calculateElement(card);

        RouteChoice = choiceTree.findRoute(resultEmotion, resultElement);

        // remove card display
        foreach (Card c in inGameHand)
        {
            Destroy(c.gameObject);
        }

        // add hand back to deck
        while(hand.Count > 0)
        {
            deck.Cards.Add(hand[hand.Count-1]);
            hand.RemoveAt(hand.Count-1);
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
