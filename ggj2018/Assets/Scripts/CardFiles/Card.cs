using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public Sprite sprite;
    public CardElement element;
    public CardElement element2;
    public CardEmotion emotion;

    public int elementStrength;
    public int pointCost;

    private Button btn;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(onClick);
    }
    void onClick()
    {
        CardManager manager = FindObjectOfType<CardManager>();
        manager.continueWithChoice(this);
    }
}
