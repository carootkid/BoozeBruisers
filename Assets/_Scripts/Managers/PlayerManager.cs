using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Manager")]
    public TurnManager turnmanager;
    public DeathManager deathManager;

    [Header("Sources")]
    public AudioSource leftSoft;
    public AudioSource leftHard;
    public AudioSource rightSoft;
    public AudioSource rightHard;

    [Header("Clips")]
    public AudioClip hardPunch;
    public AudioClip softPunch;

    [Header("Values")]
    public float damageAddition;
    public float volMult = 1f;

    public float strength = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        damageAddition = 0.0f;
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
        leftSoft.volume = (1 - strength) * volMult;
        leftHard.volume = strength * volMult;

        leftSoft.PlayOneShot(softPunch);
        leftHard.PlayOneShot(hardPunch);
    }

    void PunchEnded(){
        deathManager.deathChance();
        damageAddition = 0.0f;
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
