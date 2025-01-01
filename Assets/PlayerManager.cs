using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public TurnManager turnmanager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
