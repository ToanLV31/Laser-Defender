using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    [SerializeField] float timeToTurnGameOver = 1f;
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(LoadAndWait("Game Over", 1f));
    }



    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadAndWait(string sceneName, float timeToLoad)
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(sceneName);
    }



}
