using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    [SerializeField]
    private PlayerHorizontalMovement player;

    public static WorldManager main;
    private bool isPaused = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyManager.main.GetKey(Action.Pause)))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    void Awake()
    {
        main = this;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        // retry current level
    }

    public void SetPlayerMovement(bool letMove)
    {
        player.StartMoving();
    }

    public void Continue()
    {
        // unpause and continue
        Time.timeScale = 1f;
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        UIManager.main.HideDialog();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        UIManager.main.ShowDialog(DialogType.Pause);
    }

    public Vector3 GetPlayerPos()
    {
        return player.transform.position;
    }
}
