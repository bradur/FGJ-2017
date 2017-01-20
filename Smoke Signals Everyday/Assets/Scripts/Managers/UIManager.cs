using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class UIManager : MonoBehaviour {

    public static UIManager main;

    [SerializeField]
    private Text txtScore;

    void Awake()
    {
        main = this;
    }

    public void UpdateScore(int newScore)
    {
        txtScore.text = newScore.ToString();
    }

}