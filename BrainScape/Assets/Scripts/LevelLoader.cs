using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Additive);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            loadingScreen.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (progress * 100f).ToString();
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        yield return null;
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        LoadLevel(5);
    }
    
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2);
        for (float i = 1f; i >= 0; i-= 0.05f)
        {
            gameObject.GetComponent<CanvasGroup>().alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        SceneManager.UnloadSceneAsync("SceneLoadingLevel");
    }
}
