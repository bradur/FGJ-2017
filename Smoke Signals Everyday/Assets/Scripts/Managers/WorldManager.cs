using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    [SerializeField]
    private PlayerHorizontalMovement player;

    [SerializeField]
    private PlayerController playerContoller;

    public static WorldManager main;
    private bool isPaused = false;

    [SerializeField]
    private Transform worldParent;
    public Transform WorldParent { get { return worldParent; } }

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

    public void StopPlayerHorizontal()
    {
        player.StopMoving();
    }

    public void SetPlayerMovement(bool letMove)
    {
        player.StartMoving();
        playerContoller.AllowMovement = letMove;
    }

    public void ClearPlayerTrail()
    {
        playerContoller.Trail.Clear();
    }

    public void DisablePlayerTrail()
    {
        playerContoller.Trail.enabled = false;
    }

    public void EnablePlayerTrail()
    {
        playerContoller.Trail.enabled = true;
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
