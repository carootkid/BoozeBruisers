using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSelect : MonoBehaviour
{
    public Texture2D cursorTextureHover;
    public Texture2D cursorTextureNormal;

    public int cursorSize = 32;

    public Transform hitLocation;
    public Camera camera;


    private Item currentHoveredItem = null;

    void Update()
    {
        CheckItemCollision();

        if (Input.GetMouseButtonDown(0) && currentHoveredItem != null)
        {
            currentHoveredItem.Click();
        }
    }

    private void CheckItemCollision()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hitLocation.position = hit.point;
            if (hit.collider.CompareTag("Clickable"))
            {
                Item hoverScript = hit.collider.GetComponent<Item>();
                if (hoverScript != null)
                {
                    hoverScript.ResetAlpha();
                    currentHoveredItem = hoverScript;
                }
                Cursor.SetCursor(cursorTextureHover, new Vector2(cursorSize / 2, cursorSize / 2), CursorMode.Auto);
            }
            else
            {
                ResetHover();
            }
        }
        else
        {
            ResetHover();
        }
    }

    private void ResetHover()
    {
        Cursor.SetCursor(cursorTextureNormal, new Vector2(cursorSize / 2, cursorSize / 2), CursorMode.Auto);
    }
}