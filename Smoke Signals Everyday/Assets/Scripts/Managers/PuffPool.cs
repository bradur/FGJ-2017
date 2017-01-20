using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffPool : MonoBehaviour {

    [SerializeField]
    private List<PuffWave> differentPuffs;
    [SerializeField]
    private Puff puff;
    [SerializeField]
    private Transform puffContainer;

    private List<Puff> pool;
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
        differentPuffs = new List<PuffWave>(maxPool);
        for (int i = 0; i < maxPool; i++)
        {
            pool.Add((Puff)Instantiate(puff, puffContainer));
        }
    }
    
    public Puff GetPuff()
    {
        if(pool.Count > 0)
        {
            Puff tempPuff = pool[0];
            pool.RemoveAt(0);
            return tempPuff;
        }

        return null;
    }

    public void DestroyPuff(Puff deletedPuff)
    {
        pool.Add(deletedPuff);
        deletedPuff.gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class PuffWave : System.Object
{
    public string Name;
    public Sprite Puff;
    public Sprite Wave;
}