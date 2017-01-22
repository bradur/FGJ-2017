// Date   : 21.01.2017 02:30
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

public class WaveCollision : MonoBehaviour {

    public void BallEnter()
    {
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("Show");
    }

    public void BallExit()
    {
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("Hide");
    }

}
