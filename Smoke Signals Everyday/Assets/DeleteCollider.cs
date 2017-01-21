using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wave")
        {
            GameObject waveCollider = collision.gameObject;
            Transform waveObject = waveCollider.transform.parent;
            PuffWave puffWave = waveObject.parent.GetComponent<PuffWave>();
            
            LevelManager.main.DeletedPuffWave();

            UIManager.main.ShowScore(ScoreManager.main.GetScorePercentage());
            ScoreManager.main.ResetScore();

            PuffPool.main.DestroyPuff(puffWave);
            WorldManager.main.ClearPlayerTrail();
            WorldManager.main.DisablePlayerTrail();
        }
    }
}
