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
        if (cardName == "Judgement Pistols")
        {
            Debug.Log("Judgement pistols cuh");
        }
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
    }

    private void Start()//debugging to test card drawing
    {
        Card drawnCard = DrawCard();
        if (drawnCard != null)
        {
            Debug.Log($"You drew: {drawnCard.cardName}");
            drawnCard.CardEffect(); 
        }
        else
        {
            Debug.Log("No card drawn.");
        }
    }
}
