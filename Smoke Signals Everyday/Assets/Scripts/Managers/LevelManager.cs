using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private List<Level> levels;

    private List<PuffWave> levelObjs;

    Level currentLevel = null;

    public static LevelManager main;

    private int debugTimer = 0;

    private void Awake()
    {
        main = this;
    }

    // Use this for initialization
    void Start () {
        levelObjs = new List<PuffWave>();
	}
	
	// Update is called once per frame
	void Update () {
        debugTimer++;
	    if(currentLevel == null)
        {
            LoadNextLevel();
        }
        if(debugTimer > 60*5)
        {
            debugTimer = 0;
            LoadNextLevel();
        }
	}

    public void LoadNextLevel()
    {
        if(levels.Count == 0)
        {
            return;
        }

        if(levelObjs.Count > 0)
        {
            for(int i = 0; i < levelObjs.Count; i++)
            {
                PuffWave obj = levelObjs[i];
                if(obj != null)
                {
                    PuffPool.main.DestroyPuff(obj);
                }
            }

            levelObjs = new List<PuffWave>();
        }

        currentLevel = levels[0];
        Debug.Log(currentLevel.levelNumber);
        levels.RemoveAt(0);
        levelObjs.AddRange(currentLevel.PuffWaveIds.Select(x => PuffPool.main.GetPuff(x)));
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
