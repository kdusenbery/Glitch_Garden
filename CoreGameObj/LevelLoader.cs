using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float waitTime = 4f;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartMenuFromSplash());
        }
    }

    private IEnumerator LoadStartMenuFromSplash()
    {
        yield return new WaitForSeconds(waitTime);
        LoadStartMenu();
    }

    public void LoadStartMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadGameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Game_Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
