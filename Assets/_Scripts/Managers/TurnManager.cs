using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public bool PlayerOneTurn;          
    public GameObject PlayerOneCamera;
    public GameObject PlayerTwoCamera; 
    
    public GameObject LeftPunchCam;
    public GameObject RightPunchCam;

    [HideInInspector]
    public bool punching = false; 

    void Start()
    {

        UpdateCameraState();
    }

    void Update()
    {
        
        UpdateCameraState();
    }

    private void UpdateCameraState()
    {
        if(!punching)
        {
            PlayerOneCamera.SetActive(PlayerOneTurn);
            PlayerTwoCamera.SetActive(!PlayerOneTurn);
            LeftPunchCam.SetActive(false);
            RightPunchCam.SetActive(false);
        }
        else
        {
            PlayerOneCamera.SetActive(false);
            PlayerTwoCamera.SetActive(false);
            LeftPunchCam.SetActive(PlayerOneTurn);
            RightPunchCam.SetActive(!PlayerOneTurn);
        }        
    }
}