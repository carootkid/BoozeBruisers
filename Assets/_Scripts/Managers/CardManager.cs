using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public int rarityWeight; // higher it is, the more common
    public GameObject cardPrefab;

    // Name the cards and what they do when drawn
    public void CardEffect()
    {

    }
}

public class CardManager : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();

    private int WeightCalculation()
    {
        int totalWeight = 0;

        foreach (Card card in cardList)
        {
            totalWeight += card.rarityWeight;
        }
        return totalWeight;
    }

    public Card DrawCard()
    {
        int totalWeight = WeightCalculation();

        if (totalWeight <= 0)
        {
            Debug.LogError("The weight is 0 or negative, so nothing happens.");
            return null;
        }

        int randomNumber = Random.Range(0, totalWeight);
        Debug.Log("Random Number:" + randomNumber);
        Debug.Log("The total weight is:" + totalWeight);

        foreach (Card card in cardList)
        {
            if (randomNumber < card.rarityWeight)
            {
                return card;
            }
            randomNumber -= card.rarityWeight; 
        }

        Debug.LogError("Failed to draw a card.");
        return null;
        //To try and explain how it works basically it adds up all the cards weighting together to get a range (0 - whatever the total card weighting is)
        //then it picks a random number and if that number is within a range of a card it picks that card, like if ones weighting was 10, every number from 0-9 could be chosen for it
    }

}
