using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public ZonkManager zonkManager;
    public TurnManager turnManager;
    public PlayerManager playerManager;
    public float deathChanceMultiplier = 0.01f;

    void Start()
    {
        zonkManager = FindObjectOfType<ZonkManager>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    public void deathChance()
    {
        float playerOneDeathChance = zonkManager.PlayerOneZonkLevel * deathChanceMultiplier;
        float playerTwoDeathChance = zonkManager.PlayerTwoZonkLevel * deathChanceMultiplier;

        float randomValue = Random.value;

        if (randomValue < playerOneDeathChance)
        {
            Debug.Log("Player 1 died");
            EndGame();
            return;
        }

        if (randomValue < playerTwoDeathChance)
        {
            Debug.Log("Player 2 died");
            EndGame();
            return;
        }

        Debug.Log("Survived");
    }

    private void EndGame()
    {
        Debug.Log("GAME OVER");
        
    }
}
