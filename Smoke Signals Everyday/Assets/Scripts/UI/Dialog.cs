// Date   : 21.01.2017 14:17
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Text txtTitle;
    [SerializeField]
    private Text txtMessage;

    [SerializeField]
    private bool isFailDialog;

    [SerializeField]
    private GameObject exitButton;

    [SerializeField]
    private GameObject tryAgainButton;

    [SerializeField]
    private GameObject continueButton;

    bool isShown = false;

    public void Show(DialogType dialogType)
    {
        gameObject.SetActive(true);
        if (isShown)
        {
            return;
        }
        isShown = true;
        if (dialogType == DialogType.Fail)
        {
            continueButton.SetActive(false);
            tryAgainButton.SetActive(true);
        }
        else if (dialogType == DialogType.Success || dialogType == DialogType.Pause)
        {
            tryAgainButton.SetActive(false);
            continueButton.SetActive(true);
        }
        animator.SetTrigger("Show");
    }

    public void Hide()
    {
        animator.SetTrigger("Hide");
        isShown = false;
    }

    public void Exit()
    {
        WorldManager.main.Exit();
    }

    public void Retry()
    {
        WorldManager.main.Retry();
    }

    public void Continue()
    {
        WorldManager.main.Continue();
    }
}
