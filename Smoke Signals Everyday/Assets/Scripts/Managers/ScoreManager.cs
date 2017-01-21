// Date   : 21.01.2017 00:37
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager main;

    private int currentWaveScore = 0;
    [SerializeField]
    [Range(1, 10)]
    private int scorePerTick = 1;

    void Awake()
    {
        main = this;
    }

    public void AddScoreFromWave()
    {
        currentWaveScore += scorePerTick;
        UIManager.main.UpdateScore(currentWaveScore);
    }

    public void ResetScore()
    {
        currentWaveScore = 0;
        UIManager.main.UpdateScore(currentWaveScore);
    }

}