using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private List<Level> levels;
    private List<Level> previousLevels;
    private List<AnimPuff> oldAnims;

    [SerializeField]
    private Transform puffPlace;

    [SerializeField]
    private AnimPuff animPuff;

    private List<PuffWave> levelObjs;
    private List<PuffWave> allLevelObjs;

    Level currentLevel = null;

    public static LevelManager main;
    private PuffWave currentPuffWave = null;
    private bool lastPuffWave = false;
    private SpriteRenderer puffAnimRenderer;

    private void Awake()
    {
        main = this;
    }

    // Use this for initialization
    void Start () {
        levelObjs = new List<PuffWave>();
        animPuff = Resources.Load<AnimPuff>("AnimPuff");
        allLevelObjs = new List<PuffWave>();
        previousLevels = new List<Level>();
        oldAnims = new List<AnimPuff>();
    }
	
	// Update is called once per frame
	void Update () {

        if (currentLevel == null)
        {
            LoadNextLevel();
        }
	}

    public void NextObject()
    {
        if (currentPuffWave != null)
        {
            //previous puff sprite
            AnimPuff anim = Instantiate(animPuff, puffPlace) as AnimPuff;
            oldAnims.Add(anim);
            //super magic bug slaying numbers
            anim.transform.position = puffPlace.position + new Vector3(-3.13f, 1.34f, 0);

            SpriteRenderer puffRenderer = anim.GetComponent<SpriteRenderer>();
            puffAnimRenderer = puffRenderer;

            initAnimPuff(anim, puffRenderer, currentPuffWave.Puff.Sprite);

            currentPuffWave.SetAnim(anim);
        }

        if (levelObjs != null && levelObjs.Count > 0)
        {
            currentPuffWave = levelObjs[0];
            levelObjs.RemoveAt(0);
            currentPuffWave.IsMoving = true;
            lastPuffWave = false;
        }
        else
        {
            lastPuffWave = true;
        }
    }

    private void initAnimPuff(AnimPuff anim, SpriteRenderer puffRenderer, Sprite sprite)
    {
        puffAnimRenderer.sprite = sprite;
        SetPuffAlpha(0f);
    }

    public void SetPuffAlpha(float alpha)
    {
        if (puffAnimRenderer == null) return;

        puffAnimRenderer.GetComponent<Animator>().enabled = false;
        Debug.Log("Alpha: "+alpha);
        puffAnimRenderer.color = new Color(puffAnimRenderer.color.r, puffAnimRenderer.color.g, puffAnimRenderer.color.b, alpha);
    }

    public void GameEnd()
    {
        UIManager.main.ShowDialog(DialogType.Success);
        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        if(levels.Count == 0)
        {
            GameEnd();
            return;
        }

        CleanUp();

        currentLevel = levels[0];
        Debug.Log("Level changed to: "+ currentLevel.levelNumber);
        //only add a level that's not there yet
        if (!previousLevels.Select(x => x.levelNumber).Contains(levels[0].levelNumber))
        {
            previousLevels.Add(levels[0]);
        }
        levels.RemoveAt(0);

        //var x = levelObjs[i].transform.position.x;
        Vector3 playerPos = WorldManager.main.GetPlayerPos();
        Vector3 initPos = new Vector3(playerPos.x + 15f, 0, 0);
        levelObjs.AddRange(currentLevel.PuffWaveIds.Select(x => PuffPool.main.GetPuff(x, initPos)));

        UIManager.main.SetLevel(currentLevel.dialog, new List<PuffWaveStuct>(currentLevel.PuffWaveIds.Select(x => PuffPool.main.GetPuffStuct(x))));

        for(int i = 0; i < levelObjs.Count; i++)
        {
            levelObjs[i].transform.position = new Vector3(playerPos.x + 15f, 0, 0);
        }

        allLevelObjs.AddRange(levelObjs);
        previousLevels.Last().PuffWaveIds = currentLevel.PuffWaveIds;

        NextObject();
    }

    public void RestartLevel()
    {
        ScoreManager.main.ResetScore();
        WorldManager.main.DisablePlayerTrail();
        levels.Insert(0, previousLevels.Last());
        WorldManager.main.ResetPlayer();
        currentPuffWave = null;
        CleanUp();
        LoadNextLevel();
    }

    public void DeletedPuffWave()
    {
        puffAnimRenderer.GetComponent<Animator>().enabled = true;
        if (lastPuffWave && !ScoreManager.main.CheckFailure())
        {
            LoadNextLevel();
        }
    }

    //delete puff animations
    public void DeleteAnims()
    {
        if (oldAnims != null)
        {
            Debug.Log("Old anims removed: " + oldAnims.Count);
            for (int i = 0; i < oldAnims.Count; i++)
            {
                oldAnims[i].gameObject.SetActive(false);
                Destroy(oldAnims[i].gameObject);
            }
            oldAnims = new List<AnimPuff>();
        }
    }

    //just in case, clean up if anything was left from the previous level
    private void CleanUp()
    {
        if(currentPuffWave != null)
        {
            PuffPool.main.DestroyPuff(currentPuffWave);
        }

        if(oldAnims != null)
        {
            Debug.Log("Old anims removed: " + oldAnims.Count);
            for(int i = 0; i < oldAnims.Count; i++)
            {
                oldAnims[i].gameObject.SetActive(false);
                Destroy(oldAnims[i].gameObject);
            }
            oldAnims = new List<AnimPuff>();
        }

        oldAnims = new List<AnimPuff>();

        if (allLevelObjs != null)
        {
            Debug.Log("Level obs removed: " + allLevelObjs.Count);
            for (int i = 0; i < allLevelObjs.Count; i++)
            {
                PuffWave obj = allLevelObjs[i];
                if (obj != null)
                {
                    PuffPool.main.DestroyPuff(obj);
                }
            }

            allLevelObjs = new List<PuffWave>();
        }

        if (levelObjs != null)
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
