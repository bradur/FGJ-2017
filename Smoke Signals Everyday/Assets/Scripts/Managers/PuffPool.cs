using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuffPool : MonoBehaviour {

    [SerializeField]
    private List<PuffWaveStuct> differentPuffs;
    [SerializeField]
    private PuffWave puff;
    [SerializeField]
    private Transform puffContainer;
    [SerializeField]
    private Transform worldContainer;

    private List<PuffWave> pool;
    private int maxPool = 25;
    
    public static PuffPool main;

    private void Awake()
    {
        main = this;
    }

    // Use this for initialization
    void Start () {
        Init();
	}

    private void Init()
    {
        pool = new List<PuffWave>(maxPool);
        for (int i = 0; i < maxPool; i++)
        {
            PuffWave puffwave = (PuffWave)Instantiate(puff, puffContainer);
            puffwave.gameObject.SetActive(false);
            pool.Add(puffwave);
        }
    }
    
    public PuffWave GetNewPuff()
    {
        if(pool.Count > 0)
        {
            PuffWave tempPuff = pool[0];
            pool.RemoveAt(0);
            tempPuff.gameObject.SetActive(true);
            return tempPuff;
        }

        return null;
    }

    public PuffWave GetPuff(PuffWaveID pwName)
    {
        PuffWaveStuct pw = GetPW(pwName);
        PuffWave newPuff = GetNewPuff();
        newPuff.Puff = pw.PuffWave.Puff;
        newPuff.Wave = pw.PuffWave.Wave;


        return newPuff;
    }

    public void DestroyPuff(PuffWave deletedPuff)
    {
        if (deletedPuff == null) return; 

        pool.Add(deletedPuff);
        deletedPuff.gameObject.SetActive(false);
    }

    private PuffWaveStuct GetPW(PuffWaveID id)
    {
        return differentPuffs.Where(x => x.ID == id).FirstOrDefault();
    }

    //move puffwave from PuffContainer to WorldContainer
    public void SetMoving(PuffWave pw)
    {
        pw.transform.parent = worldContainer;
    }

    //move puffwave from WorldContainer to PuffContainer
    public void SetStationary(PuffWave pw)
    {
        pw.transform.parent = puffContainer;
    }

	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class PuffWaveStuct : System.Object
{
    public PuffWaveID ID;
    public PuffWave PuffWave;
}

public enum PuffWaveID
{
    None,
    Frog,
    Garbage,
    Enemy,
    Fridge,
    Acorn
}