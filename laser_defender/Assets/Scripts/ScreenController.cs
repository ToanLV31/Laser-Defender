using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    [SerializeField] float timeToTurnGameOver = 1f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

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

    public void PlayAgain(){
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadBackMainMenu(){
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Main Menu");
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
