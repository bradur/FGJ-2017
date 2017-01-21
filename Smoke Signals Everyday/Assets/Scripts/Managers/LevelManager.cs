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
    PuffWave pw = null;

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

        if (currentLevel == null)
        {
            LoadNextLevel();
        }
        if(debugTimer == 60)
        {
            if (levelObjs != null && levelObjs.Count > 0)
            {
                pw = levelObjs[0];
                levelObjs.RemoveAt(0);
                PuffPool.main.SetMoving(pw);
            }
        }
        if (debugTimer == 60*4)
        {
            if (levelObjs != null && levelObjs.Count > 0)
            {
                PuffPool.main.DestroyPuff(pw);
                pw = levelObjs[0];
                levelObjs.RemoveAt(0);
                PuffPool.main.SetMoving(pw);
            }
        }
        if (debugTimer == 60 * 8)
        {
            if (levelObjs != null && levelObjs.Count > 0)
            {
                PuffPool.main.DestroyPuff(pw);
                pw = levelObjs[0];
                levelObjs.RemoveAt(0);
                PuffPool.main.SetMoving(pw);
            }
        }
        if (debugTimer > 60 * 20)
        {
            Debug.Log("next level!");
            debugTimer = 0;
            LoadNextLevel();
        }
	}

    public void LoadNextLevel()
    {
        if(levels.Count == 0)
        {
            //TODO: trigger game end here or before
            return;
        }

        CleanUp();

        currentLevel = levels[0];
        Debug.Log(currentLevel.levelNumber);
        levels.RemoveAt(0);
        levelObjs.AddRange(currentLevel.PuffWaveIds.Select(x => PuffPool.main.GetPuff(x)));
        for(int i = 0; i < levelObjs.Count; i++)
        {
            var x = levelObjs[i].transform.position.x;
            levelObjs[i].transform.position = new Vector3(7f, 0, 0);
        }
    }

    //just in case, clean up if anything was left from the previous level
    private void CleanUp()
    {
        if (levelObjs.Count > 0)
        {
            for (int i = 0; i < levelObjs.Count; i++)
            {
                PuffWave obj = levelObjs[i];
                if (obj != null)
                {
                    PuffPool.main.DestroyPuff(obj);
                }
            }

            levelObjs = new List<PuffWave>();
        }
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
