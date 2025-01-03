using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    
    public string cardName;
    public int rarityWeight; // higher it is, the more common
    public GameObject cardPrefab;

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
        else if (cardName == "The Sober")//Makes player 15 points less drunk
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
        else if (cardName == "The Pure")//makes player 25 points less drunk
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
        else if (cardName == "The Saint")//Removes all of the drunkness off a player
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
        else if (cardName == "AllISeeIsRed")//insantly makes player punch the other player
        {
            if(!turnManager.PlayerOneTurn)
            {
                Debug.Log("Punching Player One");

                turnManager.punching = true;

                float randPunch = Random.Range(0,101);
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

                float randPunch = Random.Range(0,101);
                float ZonkEffect = randPunch / 2;
                Debug.Log(randPunch);
                
                randPunch = randPunch / 100; 
                playerAnimator.SetFloat("Strength", randPunch);
                playerAnimator.SetTrigger("Left");
                playerAnimator.SetTrigger("Left");
                zonkManager.PlayerTwoZonkLevel = zonkManager.PlayerTwoZonkLevel + ZonkEffect;
            }
        }
        else if (cardName == "Judgement Pistols")//Person the most drunk loosesc:\Users\Broth\AppData\Local\Packages\MicrosoftWindows.Client.CBS_cw5n1h2txyewy\TempState\ScreenClip\{39EA2452-9937-40F9-806D-FC3B7A6EDED2}.png
        {
            
            if(zonkManager.PlayerOneZonkLevel > zonkManager.PlayerTwoZonkLevel){
                Debug.Log("Player One Wins");//whenever we actually make a game over screen and stuff and something to say ___ wins we put that here
            } else if(zonkManager.PlayerTwoZonkLevel > zonkManager.PlayerOneZonkLevel){
                Debug.Log("player two wins");//whenever we actually make a game over screen and stuff and something to say ___ wins we put that here
            } else {
                Debug.Log("Tie");
            }
        }
        else if(cardName == "The Alchoholic")//Forces player to drink
        {
            zonkManager.canClick = false;
        }
        else if(cardName == "Drunken Rage")//Makes punch 10 points stronger
        {
            playerManager.damageAddition = 10.0f;
        }
        else if(cardName == "Drunken Wrath")//Makes punch 20 points stronger
        {
             playerManager.damageAddition = 20.0f;
        }
        else if(cardName == "The Lightweight")//Makes next drink more potent
        {
            zonkManager.ZonkAddition = 15f;
        }
        else if(cardName == "")
        {

        }
        else if(cardName == "")
        {

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
