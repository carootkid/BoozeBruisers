using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool PlayerOneTurn;          
    public GameObject PlayerOneCamera;
    public GameObject PlayerTwoCamera; 

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
      
        PlayerOneCamera.SetActive(PlayerOneTurn);
        PlayerTwoCamera.SetActive(!PlayerOneTurn);
    }
}
