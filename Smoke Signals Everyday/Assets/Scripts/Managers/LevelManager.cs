using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private List<Level> levels;

    Level currentLevel;
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadNextLevel()
    {
        currentLevel = levels[0];
        levels.RemoveAt(0);

    }
}

[System.Serializable]
public class Level
{
    public int levelNumber;
    public List<PuffWaveID> PuffWaveIds;

    [TextArea]
    public string dialog;
}
