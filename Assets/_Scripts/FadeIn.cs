using System.Collections;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject fadeScreen;
    public CanvasGroup fadeCanvasGroup; 
    public float fadeDuration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        fadeScreen.SetActive(true);
        fadeCanvasGroup.alpha = 1; 
        fadeCanvasGroup.interactable = true;
        fadeCanvasGroup.blocksRaycasts = true;

        StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        float elapsedTime = 0f;

   
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeCanvasGroup.alpha = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = 0f;
        fadeCanvasGroup.interactable = false;
        fadeCanvasGroup.blocksRaycasts = false;
    }
}
