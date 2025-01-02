using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Manager")]
    public TurnManager turnmanager;

    [Header("Sources")]
    public AudioSource leftSoft;
    public AudioSource leftHard;
    public AudioSource rightSoft;
    public AudioSource rightHard;

    [Header("Clips")]
    public AudioClip hardPunch;
    public AudioClip softPunch;

    [Header("Values")]
    public float volMult = 1f;

    public float strength = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LeftPunch(){
        rightSoft.volume = (1 - strength) * volMult;
        rightHard.volume = strength * volMult;

        rightSoft.PlayOneShot(softPunch);
        rightHard.PlayOneShot(hardPunch);
    }
    void RightPunch(){
        leftSoft.volume = 1 - strength;
        leftHard.volume = strength;

        leftSoft.PlayOneShot(softPunch);
        leftHard.PlayOneShot(hardPunch);
    }

    void PunchEnded(){
        turnmanager.PlayerOneTurn = !turnmanager.PlayerOneTurn;
        turnmanager.punching = false;
    }

    void LeftInit(){
        turnmanager.PlayerOneTurn = !turnmanager.PlayerOneTurn;
    }
    void RightInit(){
        turnmanager.PlayerOneTurn = !turnmanager.PlayerOneTurn;
    }
}
