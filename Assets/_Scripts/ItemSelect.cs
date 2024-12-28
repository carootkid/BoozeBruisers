using UnityEngine;
using TMPro;

public class ItemSelect : MonoBehaviour
{
    public Texture2D cursorTextureHover;
    public Texture2D cursorTextureNormal;

    public int cursorSize = 32;

    public Transform hitLocation;
    public Camera camera;

    private bool isHover;

    void Update()
    {
        // Check for collisions when the mouse is over an item
        CheckItemCollision();

        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Clicked");
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
                Item clickScript = hit.collider.GetComponent<Item>();
                if(Input.GetMouseButtonDown(0) && clickScript != null)
                {
                    clickScript.Click();
                }
                Cursor.SetCursor(cursorTextureHover, new Vector2(cursorSize / 2, cursorSize / 2), CursorMode.Auto);
            } else {
                Cursor.SetCursor(cursorTextureNormal, new Vector2(cursorSize / 2, cursorSize / 2), CursorMode.Auto);
            }
        } else
        {
            Cursor.SetCursor(cursorTextureNormal, new Vector2(cursorSize / 2, cursorSize / 2), CursorMode.Auto);
        }
    }
}
