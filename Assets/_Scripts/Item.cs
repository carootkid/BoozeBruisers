using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public string itemName = "";
    public string itemDesc = "";
    public TMP_Text textMeshPro;
    public ZonkManager zonkManager;

    void Start()
    {
        zonkManager = FindObjectOfType<ZonkManager>();
        if (textMeshPro != null)
        {
            textMeshPro.text = "Zonk Level: 0";
        }
    }

    void Update()
    {
        if (textMeshPro != null && zonkManager != null)
        {
            textMeshPro.text = "Zonk Level: " + zonkManager.ZonkLevel;
        }
    }

    public void Click()
    {
        if (itemName == "Leaf Lubber")
        {
            Debug.Log("Clicked Leaf Lubber");
            zonkManager.ZonkLevel += 10;
        }
        if (itemName == "Trigger Sappy")
        {
            Debug.Log("Clicked Trigger Sappy");
            zonkManager.ZonkLevel += 20;
        }
        if (itemName == "Mighty Moonshine")
        {
            Debug.Log("Clicked Mighty Moonshine");
            zonkManager.ZonkLevel += 30;
        }
        if (itemName == "House Fire")
        {
            Debug.Log("Clicked House Fire");
            zonkManager.ZonkLevel += 50;
        }
    }
}
