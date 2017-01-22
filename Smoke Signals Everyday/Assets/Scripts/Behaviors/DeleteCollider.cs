using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollider : MonoBehaviour {

    [SerializeField]
    private GameObject fizzleObject;

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
            puffWave.PuffAnimOut();
            
            UIManager.main.ShowScore(ScoreManager.main.GetScorePercentage());
            if (ScoreManager.main.CheckFailure())
            {
                fizzleObject.GetComponent<Animator>().SetTrigger("Fizzle");
                UIManager.main.ShowDialog(DialogType.Fail);
                fizzleObject.SetActive(true);
                LevelManager.main.DeleteAnims();
                Time.timeScale = 0f;
            }

            LevelManager.main.DeletedPuffWave();

            ScoreManager.main.ResetScore();

            WorldManager.main.StopPlayerHorizontal();

            PuffPool.main.DestroyPuff(puffWave);
            WorldManager.main.ClearPlayerTrail();
            WorldManager.main.DisablePlayerTrail();
        }
    }
}
