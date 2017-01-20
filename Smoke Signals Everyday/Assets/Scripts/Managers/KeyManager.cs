using UnityEngine;
using System.Collections.Generic;

public enum Action
{
    None,
    MoveUp
}

public class KeyManager : MonoBehaviour {

    public static KeyManager main;

    private void Awake()
    {
        main = this;
    }

    [SerializeField]
    private List<GameKey> gameKeys = new List<GameKey>();

    public KeyCode GetKey(Action action)
    {
        foreach(GameKey gameKey in gameKeys)
        {
            if (gameKey.action == action)
            {
                return gameKey.key;
            }
        }
        return KeyCode.None;
    }
}


[System.Serializable]
public class GameKey : System.Object
{
    public KeyCode key;
    public Action action;
}