using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject CreditsScreen;
    public GameObject SettingsScreen;

    private CanvasGroup mainCanvasGroup;
    private CanvasGroup creditsCanvasGroup;
    private CanvasGroup settingsCanvasGroup;

    public GameObject fadeScreen; // low taper fadeeeee
    private CanvasGroup fadeCanvasGroup;

    public float fadeDuration = 0.5f; // fade duration if i want to change it
    public AudioClip clickSound;
    public AudioSource audioSource;

    void Start()
    {
        mainCanvasGroup = MainScreen.GetComponent<CanvasGroup>();
        creditsCanvasGroup = CreditsScreen.GetComponent<CanvasGroup>();
        settingsCanvasGroup = SettingsScreen.GetComponent<CanvasGroup>();

        fadeCanvasGroup = fadeScreen.GetComponent<CanvasGroup>();
        fadeScreen.SetActive(true);
        fadeCanvasGroup.alpha = 0;

        StartCoroutine(FadeToScreen(mainCanvasGroup));

        if (MainScreen == null || CreditsScreen == null || SettingsScreen == null || fadeScreen == null)
        {
            Debug.LogError("UI components are not assigned in the ScenesManager script.");
            return;
        }

    }
    private void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void Back()
    {
        PlayClickSound();
        StartCoroutine(FadeToScreen(mainCanvasGroup)); // go back to main
    }

    public void SettingsButton()
    {
        PlayClickSound();
        StartCoroutine(FadeToScreen(settingsCanvasGroup));
        //put other shit here if i need too
    }

    public void CreditsButton()
    {
        PlayClickSound();
        StartCoroutine(FadeToScreen(creditsCanvasGroup));
        //put more shit if i need too
    }

    public void PlayButton()
    {
        PlayClickSound();
        StartCoroutine(FadeToBarScene()); // lowkey forgot we needed to go to coinflip so it does that but im not renaming my shit
    }

    private IEnumerator FadeToBarScene()
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

        SceneManager.LoadScene("Coin Flip"); // I accidentally made it go to bar scene cause i forgot about coin flip but im too lazy to rename all my code to CoinFlipScene so fuck you
    }

    private IEnumerator FadeToScreen(CanvasGroup targetCanvasGroup) // takes alpha and stuff and makes it 0 then go up slowly and then be 1 at end
    {
        DisableAllScreens();

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
        targetCanvasGroup.interactable = true;
        targetCanvasGroup.blocksRaycasts = true;
    }

    private void DisableAllScreens() // get rid of EVERYTHING!!!!!!
    {
        DisableScreen(mainCanvasGroup);
        DisableScreen(creditsCanvasGroup);
        DisableScreen(settingsCanvasGroup);
    }

    private void DisableScreen(CanvasGroup canvasGroup) // disable certain things depending on canvas groups
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.gameObject.SetActive(false);
    }
}
