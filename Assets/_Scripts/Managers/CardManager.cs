using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    public int rarityWeight; 
    public GameObject cardPrefab;
    public bool goodCard;

    [HideInInspector]
    public int calculatedWeight;

    private ZonkManager zonkManager;
    private TurnManager turnManager;
    private PlayerManager playerManager;
    private Item item;
    private float DrunkLevel;
    public Animator playerAnimator;
    public bool CardIsDone;

    private void InitializeManagers()
    {
        GameObject managerObject = GameObject.FindObjectOfType<CardManager>()?.gameObject;

        zonkManager = managerObject.GetComponent<ZonkManager>();
        turnManager = managerObject.GetComponent<TurnManager>();

        GameObject playersObject = GameObject.Find("Players");
        if (playersObject != null)
        {
            playerManager = playersObject.GetComponent<PlayerManager>();
        }
        else
        {
            Debug.LogError("Players GameObject is missing or cannot be found!");
        }

        item = GameObject.FindObjectOfType<Item>();

        if (zonkManager == null) Debug.LogError("ZonkManager is missing!");
        if (turnManager == null) Debug.LogError("TurnManager is missing!");
        if (playerManager == null) Debug.LogError("PlayerManager is missing!");
        if (item == null) Debug.LogError("Item component is missing!");
    }

    public void CardEffect()
    {
        InitializeManagers();

        if (cardName == "Drunkify") // Makes player more drunk a random amount
        {
            DrunkLevel = Random.Range(10, 30);
            if (turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += DrunkLevel;
            }
            else
            {
                zonkManager.PlayerTwoZonkLevel += DrunkLevel;
            }
        }
        else if (cardName == "The Sober") // Makes player 15 points less drunk
        {
            if (turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel -= 15;
            }
            else
            {
                zonkManager.PlayerTwoZonkLevel -= 15;
            }

        }
        else if (cardName == "The Pure") // makes player 25 points less drunk
        {
            if (turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel -= 25;
            }
            else
            {
                zonkManager.PlayerTwoZonkLevel -= 25;
            }
        }
        else if (cardName == "The Saint") // Removes all of the drunkenness off a player
        {
            if (turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel -= zonkManager.PlayerOneZonkLevel;
            }
            else
            {
                zonkManager.PlayerTwoZonkLevel -= zonkManager.PlayerTwoZonkLevel;
            }
        }
        else if (cardName == "AllISeeIsRed") // Instantly makes player punch the other player
        {
            if (!turnManager.PlayerOneTurn)
            {
                Debug.Log("Punching Player One");

                turnManager.punching = true;

                float randPunch = Random.Range(0, 101);
                float ZonkEffect = randPunch / 2;
                Debug.Log(randPunch);

                randPunch = randPunch / 100;
                playerManager.strength = randPunch;
                playerAnimator.SetFloat("Strength", randPunch);
                playerAnimator.SetTrigger("Right");
                zonkManager.PlayerOneZonkLevel = zonkManager.PlayerOneZonkLevel + ZonkEffect;
            }
            else
            {
                Debug.Log("Punching Player Two");

                turnManager.punching = true;

                float randPunch = Random.Range(0, 101);
                float ZonkEffect = randPunch / 2;
                Debug.Log(randPunch);

                randPunch = randPunch / 100;
                playerAnimator.SetFloat("Strength", randPunch);
                playerAnimator.SetTrigger("Left");
                playerAnimator.SetTrigger("Left");
                zonkManager.PlayerTwoZonkLevel = zonkManager.PlayerTwoZonkLevel + ZonkEffect;
            }
        }
        else if (cardName == "Judgement Pistols") // Person the most drunk wins
        {

            if (zonkManager.PlayerOneZonkLevel > zonkManager.PlayerTwoZonkLevel)
            {
                Debug.Log("Player One Wins"); // whenever we actually make a game over screen and stuff and something to say ___ wins we put that here
            }
            else if (zonkManager.PlayerTwoZonkLevel > zonkManager.PlayerOneZonkLevel)
            {
                Debug.Log("Player Two Wins"); // whenever we actually make a game over screen and stuff and something to say ___ wins we put that here
            }
            else
            {
                Debug.Log("Tie");
            }
        }
        else if (cardName == "The Alchoholic") // Forces player to drink
        {
            zonkManager.canClick = false;
        }
        else if (cardName == "Drunken Rage") // Makes punch 10 points stronger
        {
            playerManager.damageAddition = 10.0f;
        }
        else if (cardName == "Drunken Wrath") // Makes punch 20 points stronger
        {
            playerManager.damageAddition = 20.0f;
        }
        else if (cardName == "The Lightweight") // Makes next drink more potent
        {
            zonkManager.ZonkAddition = 15f;
        }
        else if (cardName == "The Devil") // Sets your drunkenness to 50, makes you do much more damage
        {
            if (turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 50.0f;
                playerManager.damageAddition = 99.0f;
            }
            else
            {
                zonkManager.PlayerTwoZonkLevel += 50.0f;
                playerManager.damageAddition = 99.0f;
            }

        }
        else if (cardName == "The Haunted")
        {

        }
        else if (cardName == "Big Boned")//lesszon
        {
            zonkManager.ZonkAddition = -20f;
        }
        else if (cardName == "The Middle Finger")
        {
            
        }
        else if (cardName == "Iron Body")
        {

        }

    }
}

public class CardManager : MonoBehaviour
{
    private ZonkManager zonkManager;
    private TurnManager turnManager;
    private PlayerManager playerManager;
    public List<Card> cardList = new List<Card>();

    private float playerOneGoodCardWeightIncrement = 0f;
    private float playerTwoGoodCardWeightIncrement = 0f;

    void Start() {
        GameObject managerObject = GameObject.FindObjectOfType<CardManager>()?.gameObject;

        zonkManager = managerObject.GetComponent<ZonkManager>();
        turnManager = managerObject.GetComponent<TurnManager>();

        GameObject playersObject = GameObject.Find("Players");
        if (playersObject != null)
        {
            playerManager = playersObject.GetComponent<PlayerManager>();
        }
        else
        {
            Debug.LogError("Players GameObject is missing or cannot be found!");
        }

        if (zonkManager == null) Debug.LogError("ZonkManager is missing!");
        if (turnManager == null) Debug.LogError("TurnManager is missing!");
        if (playerManager == null) Debug.LogError("PlayerManager is missing!");
    }

    private void RecalculateWeights()
    {
    
        if (turnManager.PlayerOneTurn)
        {
            playerOneGoodCardWeightIncrement = zonkManager.PlayerOneZonkLevel / 10f;
            playerTwoGoodCardWeightIncrement = 0f; 
        }
        else
        {
            playerTwoGoodCardWeightIncrement = zonkManager.PlayerTwoZonkLevel / 10f;
            playerOneGoodCardWeightIncrement = 0f;  
        }

        Debug.Log("Recalculating weights");
        foreach (Card card in cardList)
        {
          
            int originalWeight = card.rarityWeight;

            card.calculatedWeight = originalWeight;

            if (card.goodCard)
            {
                if (turnManager.PlayerOneTurn)
                {
            
                    card.calculatedWeight += Mathf.FloorToInt(playerOneGoodCardWeightIncrement);
                }
                else
                {
        
                    card.calculatedWeight += Mathf.FloorToInt(playerTwoGoodCardWeightIncrement);
                }
            }
        }
    }

    private int WeightCalculation()
    {
        int totalWeight = 0;

        foreach (Card card in cardList)
        {
            totalWeight += card.calculatedWeight;
        }
        return totalWeight;
    }

    public Card DrawCard()
    {
        RecalculateWeights(); 
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
            if (randomNumber < card.calculatedWeight)
            {
                return card;
            }
            randomNumber -= card.calculatedWeight;
        }

        Debug.LogError("Failed to draw a card.");
        return null;
    }
}
