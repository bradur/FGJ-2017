// Date   : 21.01.2017 22:27
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;
using UnityEngine.UI;

public class FloatingScore : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Text txtScore;

    void Start () {
    
    }

    void Update () {
    
    }

    public void Show(int score)
    {
        txtScore.text = string.Format("{0}%", score.ToString());
        animator.SetTrigger("Show");

    }
}
