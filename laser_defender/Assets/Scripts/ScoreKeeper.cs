using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;



    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        Debug.Log("Score when game start: " + currentScore);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetCurrentScore()
    {
        return this.currentScore;
    }

    private void ModifyCurrentScore(int score)
    {
        currentScore = score;
    }

    public void ResetScore()
    {
        ModifyCurrentScore(0);
    }

    public void IncreaseCurrentScore(int score)
    {
        currentScore += score;
    }
}
