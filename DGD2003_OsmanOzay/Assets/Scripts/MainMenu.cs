using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private AsyncOperation asyncLoad;

    void Start()
    {
        StartCoroutine(PreloadLevel(1));
    }

    IEnumerator PreloadLevel(int sceneIndex)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void PlayGame()
    {
        if (asyncLoad != null)
        {
            asyncLoad.allowSceneActivation = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}