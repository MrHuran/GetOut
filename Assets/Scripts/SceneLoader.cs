using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public void LoadScene(string sceneName, FadeScreen fade)
    {
        StartCoroutine(LoadSceneRoutine(sceneName, fade));
    }

    public void LoadSceneFade(string sceneName)
    {
        StartCoroutine(LoadSceneFadeRoutine(sceneName));
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameRoutine());
    }

    IEnumerator LoadSceneRoutine(string sceneName, FadeScreen fade)
    {
        fade.FadeOut();
        yield return new WaitForSeconds(fade.fadeTime);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadSceneFadeRoutine(string sceneName)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeTime);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator QuitGameRoutine()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeTime);
        Application.Quit();
    }
}