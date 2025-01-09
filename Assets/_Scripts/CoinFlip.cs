using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoinFlip : MonoBehaviour
{
    [Header("Variables")]
    public Animator coinAnim;
    public bool playerOneOnHeads;
    private int coinHead;
    public bool playerOneWon = false;
    [Header("Objects")]
    public GameObject headBut;
    public GameObject tailBut;
    public GameObject playerOneWins;
    public GameObject playerTwoWins;
    public GameObject infoText;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 2f;
    [Header("Audio")]
    public AudioSource src;
    public AudioClip clp;

    private bool fadeStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, 50);

        if (randomNum > 25) coinHead = 1;
        if (randomNum <= 25) coinHead = 0;

        fadeCanvasGroup.alpha = 0f;
    }

    void coinFlipAudio()
    {
        src.PlayOneShot(clp);
    }

    void Heads()
    {
        playerOneOnHeads = true;
        flip();
    }

    void Tails()
    {
        playerOneOnHeads = false;
        flip();
    }

    void flip()
    {
        tailBut.SetActive(false);
        headBut.SetActive(false);
        infoText.SetActive(false);
        if (coinHead == 0)
        {
            coinAnim.SetTrigger("Heads");
        }
        else
        {
            coinAnim.SetTrigger("Tails");
        }

        Invoke(nameof(revealWinner), 2f);
    }

    void revealWinner()
    {
        if (playerOneOnHeads == true && coinHead == 0)
        {
            playerOneWins.SetActive(true);
            playerOneWon = true;
        }
        else if (playerOneOnHeads == false && coinHead == 1)
        {
            playerOneWins.SetActive(true);
            playerOneWon = true;
        }
        else
        {
            playerTwoWins.SetActive(true);
            playerOneWon = false;
        }

        Invoke(nameof(StartFadeIn), 2f);
    }

    void StartFadeIn()
    {
        if (!fadeStarted)
        {
            fadeStarted = true;
            StartCoroutine(FadeInRoutine());
        }
    }

    System.Collections.IEnumerator FadeInRoutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = 1f;
        SceneManager.LoadScene("AidensBar");//change to main bar scene when ready
    }
}
