// Date   : 22.01.2017 00:59
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

public class IntroCamera : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private Camera otherCamera;

    public void Start()
    {
        Time.timeScale = 0f;
        otherCamera.enabled = false;
        otherCamera.GetComponent<AudioListener>().enabled = false;
    }

    public void Kill()
    {
        otherCamera.enabled = true;
        otherCamera.GetComponent<AudioListener>().enabled = true; ;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
