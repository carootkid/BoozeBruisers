using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Item : MonoBehaviour
{
    public string itemName = "";
    public string itemDesc = "";
    public TMP_Text ItemText;
    public TMP_Text TarotCardText;
    public ZonkManager zonkManager;
    public TurnManager turnManager;

    void Start()
    {
        //Finds zonk manager and sets zonk level to 0 (NEED TO CHANGE WITH TURN SYSTEM : need to make zonk level on a player by player basis)
        zonkManager = FindObjectOfType<ZonkManager>();
        zonkManager.PlayerOneZonkLevel = 0f;
        zonkManager.PlayerTwoZonkLevel = 0f;
        //Finds turn manager and sets it to player ones turn first (NEED TO CHANGE WITH TURN SYSTEM : coin flip for who starts)
        turnManager = FindObjectOfType<TurnManager>();
        turnManager.PlayerOneTurn = true;

        //Turns off the text for the basic UI stuff as long as it exists
        if (ItemText != null) ItemText.gameObject.SetActive(false);
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

    public void Click()
    {
        //on click does stuff
        if (itemName == "Leaf Lubber")
        {
            Debug.Log("Clicked Leaf Lubber");

            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 10f;   
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 10f;
            }
            
        }
        else if (itemName == "Trigger Sappy")
        {
            Debug.Log("Clicked Trigger Sappy");
            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 20f;   
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 20f;
            }
            
        }
        else if (itemName == "Mighty Moonshine")
        {
            Debug.Log("Clicked Mighty Moonshine");
            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 30f;   
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 30f;
            }
        }
        else if (itemName == "House Fire")
        {
            Debug.Log("Clicked House Fire");
            if(turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerOneZonkLevel += 50f;   
            }
            else if (!turnManager.PlayerOneTurn)
            {
                zonkManager.PlayerTwoZonkLevel += 50f;
            }

        }
        else if(itemName == "Tarot Cards")
        {
            Debug.Log("Clicked Tarot Cards");
        }
        else if (itemName == "Player Two")
        {
            Debug.Log("Punching Player Two");
            turnManager.PlayerOneTurn = false;
        }
        else if (itemName == "Player One")
        {
            Debug.Log("Punching Player One");
            turnManager.PlayerOneTurn = true;
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
}
