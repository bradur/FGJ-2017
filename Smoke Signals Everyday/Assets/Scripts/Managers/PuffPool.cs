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

    private List<PuffWave> pool;
    private int maxPool = 100;
    
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
        differentPuffs = new List<PuffWaveStuct>(maxPool);
        for (int i = 0; i < maxPool; i++)
        {
            pool.Add((PuffWave)Instantiate(puff, puffContainer));
        }
    }
    
    public PuffWave GetNewPuff()
    {
        if(pool.Count > 0)
        {
            PuffWave tempPuff = pool[0];
            pool.RemoveAt(0);
            return tempPuff;
        }

        return null;
    }

    public PuffWave GetPuff(PuffWaveID pwName)
    {
        PuffWaveStuct pw = GetPW(pwName);
        PuffWave newPuff = GetNewPuff();
        newPuff.Puff = pw.Puff;
        newPuff.Wave = pw.Wave;

        return newPuff;
    }

    public void DestroyPuff(PuffWave deletedPuff)
    {
        pool.Add(deletedPuff);
        deletedPuff.gameObject.SetActive(false);
    }

    private PuffWaveStuct GetPW(PuffWaveID id)
    {
        return differentPuffs.Where(x => x.ID == id).FirstOrDefault();
    }

	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class PuffWaveStuct : System.Object
{
    public PuffWaveID ID;
    public Puff Puff;
    public Wave Wave;
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