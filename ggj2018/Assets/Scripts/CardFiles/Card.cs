using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour{
    public GameObject cardDescriptionText;
    public CardElement element;
    public CardElement element2;
    public CardEmotion emotion;

    public int elementStrength;
    public int pointCost;
    private GameObject cardText;

    private Button btn;

    void Start()
    {
        cardText = Instantiate(cardDescriptionText, this.transform, false);
        setDescription();
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }

    void setDescription()
    {
        string ele1 = "";
        string ele2 = "";
        string emo = "";
        if (element != CardElement.none)
        {
            ele1 = element.ToString();
        }
        if (element2 != CardElement.none)
        {
            if (ele1.Equals(""))
            {
                ele2 = element2.ToString();
            }
            else ele2 = "/" + element2.ToString();
        }
        if (element != CardElement.none)
        {
            emo = emotion.ToString();
        }
        cardText.GetComponent<Text>().text = ele1 + ele2 + ", " + emotion;
    }

    private void OnMouseOver(PointerEventData eventData)
    {
        print("test");
        print(cardText);
        cardText.SetActive(true);
    }

    private void OnMouseExit()
    {
        cardText.SetActive(false);
    }

    void onClick()
    {
        CardManager manager = FindObjectOfType<CardManager>();
        manager.continueWithChoice(this);
    }
}
