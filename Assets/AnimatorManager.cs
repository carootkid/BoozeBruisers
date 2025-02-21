using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public TurnManager turnManager;
    public GameObject leftPlayerCameraOne;
    public GameObject leftPlayerCameraTwo;

    public GameObject rightPlayerCameraOne;
    public GameObject rightPlayerCameraTwo;

    public GameObject leftCup;
    public GameObject rightCup;
    public GameObject normalCup;

    public void LeftPlayerDrinkCam(){
        leftPlayerCameraOne.SetActive(true);
        leftPlayerCameraTwo.SetActive(false);

        turnManager.drinking = true;
        
    }
    public void RightPlayerDrinkCam(){
        rightPlayerCameraOne.SetActive(true);
        rightPlayerCameraTwo.SetActive(false);

        turnManager.drinking = true;
    }

    public void LeftPlayerNrmCam(){
        leftPlayerCameraOne.SetActive(false);
        leftPlayerCameraTwo.SetActive(true);

        turnManager.drinking = false;
    }
    public void RightPlayerNrmCam(){
        rightPlayerCameraOne.SetActive(false);
        rightPlayerCameraTwo.SetActive(true);

        turnManager.drinking = false;
    }

    public void ToggleLeftCup(){
        leftCup.SetActive(!leftCup.activeInHierarchy);
        normalCup.SetActive(!normalCup.activeInHierarchy);
    }

    public void ToggleRightCup(){
        rightCup.SetActive(!rightCup.activeInHierarchy);
        normalCup.SetActive(!normalCup.activeInHierarchy);
    }
}
