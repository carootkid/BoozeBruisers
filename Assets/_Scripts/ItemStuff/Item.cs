using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Item : MonoBehaviour
{
    public string itemName = "";
    public string itemDesc = "";
    public TMP_Text ZonkMeterText;
    public TMP_Text leafLubberText;
    public TMP_Text triggerSappyText;
    public TMP_Text mightyMoonshineText;
    public TMP_Text houseFireText;
    public TMP_Text TarotCardText;
    public ZonkManager zonkManager;
    public TurnManager turnManager;

    void Start()
    {
        //Finds zonk manager and sets zonk level to 0 (NEED TO CHANGE WITH TURN SYSTEM : need to make zonk level on a player by player basis)
        zonkManager = FindObjectOfType<ZonkManager>();
        zonkManager.ZonkLevel = 0f;
        //Finds turn manager and sets it to player ones turn first (NEED TO CHANGE WITH TURN SYSTEM : coin flip for who starts)
        turnManager = FindObjectOfType<TurnManager>();
        turnManager.PlayerOneTurn = true;

        //Turns off the text for the basic UI stuff as long as it exists
        if (leafLubberText != null) leafLubberText.gameObject.SetActive(false);
        if (triggerSappyText != null) triggerSappyText.gameObject.SetActive(false);
        if (mightyMoonshineText != null) mightyMoonshineText.gameObject.SetActive(false);
        if (houseFireText != null) houseFireText.gameObject.SetActive(false);
        if (TarotCardText!= null) TarotCardText.gameObject.SetActive(false);
    }
    private void Update(){
        //Makes zonk meter gooder
        ZonkMeterText.text = "Zonk Meter :" + zonkManager.ZonkLevel;
    }

    public void Click()
    {
        //on click does stuff
        if (itemName == "Leaf Lubber")
        {
            Debug.Log("Clicked Leaf Lubber");
            zonkManager.ZonkLevel += 10f;
        }
        else if (itemName == "Trigger Sappy")
        {
            Debug.Log("Clicked Trigger Sappy");
            zonkManager.ZonkLevel += 20f;
        }
        else if (itemName == "Mighty Moonshine")
        {
            Debug.Log("Clicked Mighty Moonshine");
            zonkManager.ZonkLevel += 30f;
        }
        else if (itemName == "House Fire")
        {
            Debug.Log("Clicked House Fire");
            zonkManager.ZonkLevel += 50f;
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
        if (itemName == "Leaf Lubber" && leafLubberText != null)
        {
            leafLubberText.gameObject.SetActive(show);
            if (show) leafLubberText.text = itemDesc;
        }
        else if (itemName == "Trigger Sappy" && triggerSappyText != null)
        {
            triggerSappyText.gameObject.SetActive(show);
            if (show) triggerSappyText.text = itemDesc;
        }
        else if (itemName == "Mighty Moonshine" && mightyMoonshineText != null)
        {
            mightyMoonshineText.gameObject.SetActive(show);
            if (show) mightyMoonshineText.text = itemDesc;
        }
        else if (itemName == "House Fire" && houseFireText != null)
        {
            houseFireText.gameObject.SetActive(show);
            if (show) houseFireText.text = itemDesc;

        }else if (itemName == "Tarot Cards" && TarotCardText != null)
        {
            TarotCardText.gameObject.SetActive(show);
            if (show) TarotCardText.text = itemDesc;
        }
    }
}
