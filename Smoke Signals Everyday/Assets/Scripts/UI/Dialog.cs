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
    private Image imgForeGround;

    [SerializeField]
    private Sprite failSprite;
    [SerializeField]
    private Sprite successSprite;
    [SerializeField]
    private Sprite pauseSprite;

    [SerializeField]
    private bool isFailDialog;

    [SerializeField]
    private GameObject exitButton;

    [SerializeField]
    private GameObject tryAgainButton;

    [SerializeField]
    private GameObject continueButton;

    [SerializeField]
    private GameObject restartButton;

    bool isShown = false;

    bool isFail = false;
    bool isSuccess = false;
    bool isPause = false;

    private void Update()
    {
        if (isShown)
        {
            if (isFail)
            {
                if (Input.GetKeyUp(KeyCode.R))
                {
                    Retry();
                }
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    Application.Quit();
                }
            }
            if (isSuccess)
            {
                if (Input.GetKeyUp(KeyCode.R))
                {
                    Restart();
                }
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    Application.Quit();
                }
            }
            if (isPause)
            {
                if (Input.GetKeyUp(KeyCode.R))
                {
                    Retry();
                }
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    Application.Quit();
                }
            }
        }
    }

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
            isFail = true;
            isSuccess = false;
            isPause = false;
            restartButton.SetActive(false);
            continueButton.SetActive(false);
            tryAgainButton.SetActive(true);
            txtMessage.text = "You failed to smoke signal :(";
            txtTitle.text = "Oh no!";
            imgForeGround.sprite = failSprite;
        }
        else if (dialogType == DialogType.Success)
        {
            isFail = false;
            isSuccess = true;
            isPause = false;
            restartButton.SetActive(true);
            tryAgainButton.SetActive(false);
            continueButton.SetActive(false);
            txtMessage.text = "You failed to lose :)";
            txtTitle.text = "WIN!";
            imgForeGround.sprite = successSprite;
        }
        else if (dialogType == DialogType.Pause)
        {
            isFail = false;
            isSuccess = false;
            isPause = true;
            restartButton.SetActive(false);
            tryAgainButton.SetActive(false);
            continueButton.SetActive(true);
            txtMessage.text = "Game is paused. Press esc to continue";
            txtTitle.text = "Paused";
            imgForeGround.sprite = pauseSprite;
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

    public void Restart()
    {
        WorldManager.main.Restart();
    }
}
