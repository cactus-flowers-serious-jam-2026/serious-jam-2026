using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{

    public CanvasGroup fadeGroup;
    public float fadeSpeed = 1.5f;


    void Start()
    {
        StartCoroutine(FadeIn());
        //DontDestroyOnLoad(gameObject);
    }

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private IEnumerator FadeIn()
    {
        fadeGroup.alpha = 1f;
        fadeGroup.blocksRaycasts = true;

        while (fadeGroup.alpha > 0)
        {
            fadeGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        fadeGroup.blocksRaycasts = false;
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        fadeGroup.blocksRaycasts = true;

        while (fadeGroup.alpha < 1)
        {
            fadeGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
