using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathManager : MonoBehaviour
{
    public ZonkManager zonkManager;
    public TurnManager turnManager;
    public PlayerManager playerManager;
    public float deathChanceMultiplier = 0.01f;

    public GameObject fadeScreen;
    public CanvasGroup fadeCanvasGroup; 
    public float fadeDuration = 0.5f;
    public bool PlayerOneDied = false;
    public TMP_Text Winnertext;
    public GameObject gameOverScreen;
    private CanvasGroup GameOverGanvasGroup;

    void Start()
    {
        GameOverGanvasGroup = gameOverScreen.GetComponent<CanvasGroup>();
        zonkManager = FindObjectOfType<ZonkManager>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    public void deathChance()
    {
        float playerOneDeathChance = zonkManager.PlayerOneZonkLevel * deathChanceMultiplier;
        float playerTwoDeathChance = zonkManager.PlayerTwoZonkLevel * deathChanceMultiplier;

        float randomValue = Random.value;

        if (turnManager.PlayerOneTurn)
        {
            if (randomValue < playerTwoDeathChance)
            {
                Debug.Log("Player 2 died");
                PlayerOneDied = false;
                EndGame();
                return;
            }
        }
        else
        {
            if (randomValue < playerOneDeathChance)
            {
                Debug.Log("Player 1 died");
                PlayerOneDied = true;
                EndGame();
                return;
            }
        }

        Debug.Log("Survived");
    }

    IEnumerator FadeOutRoutine()
    {
        fadeCanvasGroup.alpha = 0;
        fadeCanvasGroup.interactable = false;
        fadeCanvasGroup.blocksRaycasts = false;

        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = 1;
        fadeCanvasGroup.interactable = true;
        fadeCanvasGroup.blocksRaycasts = true;
    }

    IEnumerator FadeInTextRoutine(CanvasGroup targetCanvasGroup)
    {
        targetCanvasGroup.gameObject.SetActive(true);

        targetCanvasGroup.alpha = 0;
        targetCanvasGroup.interactable = false;
        targetCanvasGroup.blocksRaycasts = false;

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            targetCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        targetCanvasGroup.alpha = 1;
    }

    private void EndGame()
    {
        Debug.Log("GAME OVER");
        if (PlayerOneDied)
        {
            Winnertext.text = "PLAYER TWO WINS";
        }
        else
        {
            Winnertext.text = "PLAYER ONE WINS";
        }

        StartCoroutine(EndGameRoutine());
    }

    private IEnumerator EndGameRoutine()
    {
        yield return StartCoroutine(FadeOutRoutine());
        yield return StartCoroutine(FadeInTextRoutine(GameOverGanvasGroup));

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Main Menu");
    }
}
