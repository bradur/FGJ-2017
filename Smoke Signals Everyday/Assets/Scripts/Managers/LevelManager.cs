using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private List<Level> levels;

    [SerializeField]
    private Transform puffPlace;

    [SerializeField]
    private AnimPuff animPuff;

    private List<PuffWave> levelObjs;

    Level currentLevel = null;

    public static LevelManager main;
    private PuffWave currentPuffWave = null;
    private bool lastPuffWave = false;
    private SpriteRenderer puffSprite;

    private void Awake()
    {
        main = this;
    }

    // Use this for initialization
    void Start () {
        levelObjs = new List<PuffWave>();
        puffSprite = puffPlace.GetComponent<SpriteRenderer>();
        animPuff = Resources.Load<AnimPuff>("AnimPuff");
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

            SpriteRenderer puffRenderer = anim.GetComponent<SpriteRenderer>();
            initAnimPuff(anim, puffRenderer, currentPuffWave.Puff.Sprite);
            anim.GetComponent<Animator>().SetTrigger("PuffIdle");
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
        puffRenderer.sprite = sprite;
        SetPuffAlpha(puffRenderer, 0f);
    }

    public void SetPuffAlpha(SpriteRenderer puffRenderer, float alpha)
    {
        animPuff.GetComponent<SpriteRenderer>().color = new Color(puffRenderer.color.r, puffRenderer.color.g, puffRenderer.color.b, alpha);
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
        Debug.Log("Level changed to: "+ currentLevel.levelNumber);
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

        NextObject();
    }

    public void DeletedPuffWave()
    {
        //puffPlace.GetComponent<Animator>().SetTrigger("PuffFadeOut");
        if (lastPuffWave)
        {
            LoadNextLevel();
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
