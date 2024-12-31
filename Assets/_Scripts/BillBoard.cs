using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public TurnManager turnManager;

    // Update is called once per frame
    void Update()
    {
        if (turnManager.PlayerOneTurn)
        {
            transform.LookAt(turnManager.PlayerOneCamera.transform.position);
        }
        else
        {
            transform.LookAt(turnManager.PlayerTwoCamera.transform.position);
        }

        // Lock the Z rotation to -270
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.z = -180f;
        transform.eulerAngles = eulerRotation;
    }
}
