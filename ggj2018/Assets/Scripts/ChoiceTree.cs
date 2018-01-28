using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTree : MonoBehaviour {

    public CardElement elementSuccess1;
    public CardEmotion emotionSuccess1;
    public CardElement elementSuccess2;
    public CardEmotion emotionSuccess2;

    public float percentIncrease = .3f;
    private float violentPercent;
    private float elementPercent;

    void Start()
    {

    }

    public void printGoalCompare(CardEmotion emotion, CardElement element)
    {
        print(emotionSuccess1.ToString() + ", " + elementSuccess1.ToString());
        print(emotionSuccess2.ToString() + ", " + elementSuccess2.ToString());
        print(emotion.ToString() + ", " + element.ToString());
    }

    // 0 = fail, 1 = first success, 2 = second success
    public int compareResult(CardEmotion emotion, CardElement element)
    {
        if (emotion == emotionSuccess1 && element == elementSuccess1)
        {
            return 1;
        }
        else if (emotion == emotionSuccess1 && element == elementSuccess1)
        {
            return 2;
        }
        else return 0;
    }

    public CardEmotion calculateViolence(Card card)
    {
        CardEmotion emotion = card.emotion;
        float violenceValue = Random.value;
        if (emotion == CardEmotion.random)
        {
            if (violenceValue < .5f)
            {
                emotion = CardEmotion.violent;
            }
            else emotion = CardEmotion.nonviolent;
        }

        float violence = .5f;
        if(card.emotion == CardEmotion.violent)
        {
            violence *= 1 + percentIncrease;
        }
        else if(card.emotion == CardEmotion.nonviolent)
        {
            violence *= 1 - percentIncrease;
        }

        if (violence < violenceValue)
            return CardEmotion.violent;
        else return CardEmotion.nonviolent;
    }

    public CardElement calculateElement(Card card)
    {
        CardElement e1 = card.element;
        CardElement e2 = card.element;

        float elementValue = Random.value;

        float fluid = .33f;
        float water = .33f;
        float air = .33f;

        // if random assign an element
        if(e1 == CardElement.random)
        {
            if(elementValue < fluid)
            {
                e1 = CardElement.fluid;
            }
            if (elementValue < water)
            {
                e1 = CardElement.water;
            }
            else e1 = CardElement.airborne;
        }

        if (e2 == CardElement.random)
        {
            if (elementValue < fluid)
            {
                e2 = CardElement.fluid;
            }
            if (elementValue < water)
            {
                e2 = CardElement.water;
            }
            else e2 = CardElement.airborne;
        }

        // increase percents
        if (e1 == CardElement.fluid)
        {
            fluid *= 1 + percentIncrease;
        }
        else if (e1 == CardElement.water)
        {
            water *= 1 + percentIncrease;
        }
        else if (e1 == CardElement.airborne)
        {
            air *= 1 + percentIncrease;
        }

        if (e2 == CardElement.fluid)
        {
            fluid *= 1 + percentIncrease;
        }
        else if (e2 == CardElement.water)
        {
            water *= 1 + percentIncrease;
        }
        else if (e2 == CardElement.airborne)
        {
            air *= 1 + percentIncrease;
        }

        return weighElements(fluid, water, air);
    }

    CardElement weighElements(float fluid, float water, float air)
    {
        if (fluid < water && fluid < air)
        {
            fluid = 1 - (water + air);
        }
        if (water < fluid && water < air)
        {
            water = 1 - (fluid + air);
        }
        if (air < water && air < fluid)
        {
            air = 1 - (water + fluid);
        }
        return finalizeElement(fluid, water, air);
    }

    CardElement finalizeElement(float fluid, float water, float air)
    {
        float elementValue = Random.value;
        if (elementValue < fluid)
        {
            return CardElement.fluid;
        }
        else if (elementValue < water + fluid)
        {
            return CardElement.water;
        }
        else return CardElement.airborne;
    }
}
