using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Item : MonoBehaviour
{
    [Header("Item Stuff")]
    public string itemName = "";
    public string itemDesc = "";
    public TMP_Text ItemText;
    public TMP_Text TarotCardText;


    public GameObject TVCanvas;

    [Header("Game Management")]
    public ZonkManager zonkManager;
    public TurnManager turnManager;
    public CardManager cardManager;
    public PlayerManager playerManager;

    [Header("Animator (ONLY FOR PLAYERS)")]
    public Animator playerAnimator;
    private float alpha = 0f;



    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        zonkManager = FindObjectOfType<ZonkManager>();
        zonkManager.PlayerOneZonkLevel = 0f;
        zonkManager.PlayerTwoZonkLevel = 0f;

        turnManager = FindObjectOfType<TurnManager>();

        ItemText.text = itemName;

        //Turns off the text for the basic UI stuff as long as it exists
        //if (ItemText != null) ItemText.gameObject.SetActive(false);
    }
    private void Update(){
        if(turnManager.PlayerOneTurn)
        {
            zonkManager.zonkText.text = "Zonk Level: " + zonkManager.PlayerOneZonkLevel;
        }else
        {
            zonkManager.zonkText.text = "Zonk Level: " + zonkManager.PlayerTwoZonkLevel;
        }
    }

    private void FixedUpdate() 
    {
        alpha = Mathf.Lerp(alpha, 0, Time.deltaTime * 5);

        if (ItemText != null)
        {
            ItemText.overrideColorTags = true;
            ItemText.color = new Color(1f, 1f, 1f, alpha);
        }
    }

    public void Click()
    {
        //on click does stuff
        if (itemName == "Leaf Lubber" )
        {
            Debug.Log("Clicked Leaf Lubber");

            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 10f;   
                zonkManager.PlayerOneZonkLevel += zonkManager.ZonkAddition; 
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 10f;
                zonkManager.PlayerTwoZonkLevel += zonkManager.ZonkAddition; 
            }
            zonkManager.canClick = true;
            zonkManager.ZonkAddition = 0;
           
            
        }
        else if (itemName == "Trigger Sappy")
        {
            Debug.Log("Clicked Trigger Sappy");
            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 20f;  
                zonkManager.PlayerOneZonkLevel += zonkManager.ZonkAddition;  
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 20f;
                zonkManager.PlayerTwoZonkLevel += zonkManager.ZonkAddition; 
            }
            zonkManager.canClick = true;
            zonkManager.ZonkAddition = 0;
    
            
        }
        else if (itemName == "Mighty Moonshine")
        {
            Debug.Log("Clicked Mighty Moonshine");
            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 30f; 
                zonkManager.PlayerOneZonkLevel += zonkManager.ZonkAddition;   
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 30f;
                zonkManager.PlayerTwoZonkLevel += zonkManager.ZonkAddition; 
            }
            zonkManager.canClick = true;
            zonkManager.ZonkAddition = 0;
         
        }
        else if (itemName == "House Fire")
        {
            Debug.Log("Clicked House Fire");
            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 50f; 
                zonkManager.PlayerOneZonkLevel += zonkManager.ZonkAddition;  
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 50f;
                zonkManager.PlayerTwoZonkLevel += zonkManager.ZonkAddition;  
            }
            zonkManager.canClick = true;
            zonkManager.ZonkAddition = 0;
        

        }
        else if(itemName == "Tarot Cards" && zonkManager.canClick)
        {
            Debug.Log("Clicked Tarot Cards");
            Card drawnCard = cardManager.DrawCard();
            drawnCard.CardEffect();
            if(drawnCard != null){
                Debug.Log($"You drew: {drawnCard.cardName}");
            }else{
                Debug.Log("No Card drawn");
            }
        }
        else if (itemName == "Player Two" && zonkManager.canClick)
        {
            Debug.Log("Punching Player Two");

            turnManager.punching = true;

            float randPunch = Random.Range(0,101);
            randPunch += playerManager.damageAddition;
            float ZonkEffect = randPunch / 2;
            Debug.Log(randPunch);
            randPunch = randPunch / 100; 
            playerAnimator.SetFloat("Strength", randPunch);
            playerAnimator.SetTrigger("Left");
            zonkManager.PlayerTwoZonkLevel = zonkManager.PlayerTwoZonkLevel + ZonkEffect;

        }
        else if (itemName == "Player One" && zonkManager.canClick)
        {
            Debug.Log("Punching Player One");

            turnManager.punching = true;
            float randPunch = Random.Range(0,101);
            randPunch += playerManager.damageAddition;
            float ZonkEffect = randPunch / 2;
            Debug.Log(randPunch);
            randPunch = randPunch / 100;
            playerManager.strength = randPunch;
            playerAnimator.SetFloat("Strength", randPunch);
            playerAnimator.SetTrigger("Right");
            zonkManager.PlayerOneZonkLevel = zonkManager.PlayerOneZonkLevel + ZonkEffect;

        }
        else if (itemName == "Box TV")
        {
            Debug.Log("Turning on TV");
            if(TVCanvas.activeSelf){
                TVCanvas.SetActive(false);
            }else{
                TVCanvas.SetActive(true);
            }
        }
    }

    public void ShowDescription(bool show)
    {
        //shows the description of the stuff when you hover over it and makes it so the text equals whatever is the item description
        if (itemName == "Leaf Lubber" && ItemText != null)
        {
            ItemText.gameObject.SetActive(show);
            if (show) ItemText.text = itemDesc;
        }
        else if (itemName == "Trigger Sappy" && ItemText != null)
        {
            ItemText.gameObject.SetActive(show);
            if (show) ItemText.text = itemDesc;
        }
        else if (itemName == "Mighty Moonshine" && ItemText != null)
        {
            ItemText.gameObject.SetActive(show);
            if (show) ItemText.text = itemDesc;
        }
        else if (itemName == "House Fire" && ItemText != null)
        {
            ItemText.gameObject.SetActive(show);
            if (show) ItemText.text = itemDesc;

        }else if (itemName == "Tarot Cards" && ItemText != null)
        {
            ItemText.gameObject.SetActive(show);
            if (show) ItemText.text = itemDesc;
        }
    }

    public void ResetAlpha()
    {
        alpha = 1f;
    }
    

}
