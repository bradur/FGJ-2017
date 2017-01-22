// Date   : 21.01.2017 00:37
// Project: Smoke Signals Everyday
// Author : bradur

using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager main;

    private int currentWaveScore = 0;
    [SerializeField]
    [Range(1, 10)]
    private int scorePerTick = 1;

    [SerializeField]
    [Range(0, 100)]
    private int winScoreLimit = 75;

    [SerializeField]
    private int magicOneHundredPercentScore = 28;

    void Awake()
    {
        main = this;
    }

    public int GetScore()
    {
        return currentWaveScore;
    }

    public void AddScoreFromWave()
    {
        currentWaveScore += scorePerTick;
        //UIManager.main.SetScore(currentWaveScore);
        LevelManager.main.SetPuffAlpha(currentWaveScore * 1.0f / magicOneHundredPercentScore);
    }

    public int GetScorePercentage()
    {
        return (int)(currentWaveScore * 1.0f / magicOneHundredPercentScore * 1.0f * 100);
    }

    public bool CheckFailure()
    {
        if(GetScorePercentage() > winScoreLimit)
        {
            return false;
        }

        return true;
    }

    public void ResetScore()
    {
        currentWaveScore = 0;
        //UIManager.main.SetScore(currentWaveScore);
    }

}
