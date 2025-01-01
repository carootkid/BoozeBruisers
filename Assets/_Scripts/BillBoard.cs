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
            Vector3 eulerRotation = transform.eulerAngles;
            eulerRotation.z = turnManager.PlayerOneCamera.transform.rotation.z - 180;
            transform.eulerAngles = eulerRotation;
        }
        else
        {
            transform.LookAt(turnManager.PlayerTwoCamera.transform.position);
            Vector3 eulerRotation = transform.eulerAngles;
            eulerRotation.z = turnManager.PlayerTwoCamera.transform.rotation.z - 180;
            transform.eulerAngles = eulerRotation;
        }

        
    }
}
