using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour {


    public string routeAV = "sc1_hub2";
    public string routeAN = "sc1_hub2";
    public string routeCV = "sc1_hub2";
    public string routeCN = "sc1_hub2";
    public string routeWV = "sc1_hub2";
    public string routeWN = "sc1_hub2";

    public int handSize = 8;
    public CardList cardList;

    public Deck deckPrefab;

    //private Deck deck;
    private List<Card> hand;    // virtual hand from deck
    private List<Card> inGameHand; // hand in the scene

    private Canvas canvas;
    public ChoiceTree choiceTree;

    //// card start coordinates
    //private int cardX = -383;
    //private int cardY = 77;
    ////card spacing
    //private int cardXspace = 152;
    //private int cardYspace = 222;

    // initial anchors
    Vector2 minAnchor = new Vector2(.025f, .46f);
    Vector2 maxAnchor = new Vector2(.16f, .83f);
    
    // distance between cards
    float anchorX = .1614f;
    float anchorY = .42f;

    // Instructions
    private string instructions;

    private RouteChoice routeChoice;

    // Use this for initialization
    void Start() {
        //deck = Instantiate(deckPrefab);

        canvas = this.transform.GetChild(0).GetComponent<Canvas>();

        //DontDestroyOnLoad(deck);
        //DontDestroyOnLoad(this.gameObject);

       drawHand();
    }

    public void drawHand()
    {
        hand = new List<Card>();
        inGameHand = new List<Card>();

        Vector2 min = minAnchor;
        Vector2 max = maxAnchor;

        while (hand.Count < handSize /* && deck.Cards.Count > 0 */)
        {
            //Card card = deck.drawFromDeck();
            Card card = cardList.getRandomCard();
            hand.Add(card);
            Card inGameCard = Instantiate(card, canvas.transform);
            inGameHand.Add(inGameCard);
            if (hand.Count == 5)
            {
                min = minAnchor;
                max = maxAnchor;
                min.y -= anchorY;
                max.y -= anchorY;
            }
            inGameCard.GetComponent<RectTransform>().anchorMin = min;
            inGameCard.GetComponent<RectTransform>().anchorMax = max;
            min.x += anchorX;
            max.x += anchorX;


            inGameCard.GetComponent<RectTransform>().offsetMax = new Vector2();
            inGameCard.GetComponent<RectTransform>().offsetMin = new Vector2();
        }
      
        instructions = "What is your command?";
       // GameManager._instance.DisplayTurnText(instructions);
    }

    // user has chosen a card
    public void continueWithChoice(Card card)
    {
        CardEmotion resultEmotion = choiceTree.calculateViolence(card);
        CardElement resultElement = choiceTree.calculateElement(card);
     
        instructions = "You chose a " + card.cardDescriptionText.GetComponent<Text>().text + " approach. The zombies decided to take a "
            + resultEmotion.ToString() + ", " + resultElement + " approach!";

        GameManager._instance.DisplaySelectionText(instructions);
        routeChoice = choiceTree.findRoute(resultEmotion, resultElement);

        // remove card display
        foreach (Card c in inGameHand)
        {
            Destroy(c.gameObject);
        }

        // add hand back to deck
        //while(hand.Count > 0)
        //{
        //    deck.Cards.Add(hand[hand.Count-1]);
        //    hand.RemoveAt(hand.Count-1);
        //}
    }

    public string getSceneName()
    {
        switch (routeChoice)
        {
            case RouteChoice.AirViolent: return routeAN; break;
            case RouteChoice.AirNon: return routeAV; break;
            case RouteChoice.ContactViolent: return routeCV; break;
            case RouteChoice.ContactNon: return routeCN; break;
            case RouteChoice.WaterViolent: return routeWV; break;
            case RouteChoice.WaterNon: return routeWN; break;
        }
        return "main";
    }

    public void loadNextScene()
    {
        switch(routeChoice)
        {
            case RouteChoice.AirViolent: SceneManager.LoadScene(routeAN); break;
            case RouteChoice.AirNon: SceneManager.LoadScene(routeAV); break;
            case RouteChoice.ContactViolent: SceneManager.LoadScene(routeCV); break;
            case RouteChoice.ContactNon: SceneManager.LoadScene(routeCN); break;
            case RouteChoice.WaterViolent: SceneManager.LoadScene(routeWV); break;
            case RouteChoice.WaterNon: SceneManager.LoadScene(routeWN); break;
        }
    }

    public int GetRouteChoiceId()
    {
        switch (routeChoice)
        {
            case RouteChoice.AirViolent: return 0;
            case RouteChoice.AirNon: return 1;
            case RouteChoice.ContactViolent: return 2;
            case RouteChoice.ContactNon: return 3;
            case RouteChoice.WaterViolent: return 4;
            case RouteChoice.WaterNon: return 5;
        }
       
        return 0;
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
