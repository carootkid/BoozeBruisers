using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public ZonkManager zonkManager;
    public TurnManager turnManager;

    void Start()
    {
        zonkManager = FindObjectOfType<ZonkManager>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    void Update()
    {
        
    }
}
