// Date   : 21.01.2017 02:30
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

public class WaveCollision : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    public Animator Animator { set { animator = value; } }

    public void BallEnter()
    {
        animator.SetTrigger("BallEnter");
    }

    public void BallExit()
    {
        animator.SetTrigger("BallExit");
    }

}
