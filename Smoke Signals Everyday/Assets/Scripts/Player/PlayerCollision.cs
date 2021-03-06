// Date   : 21.01.2017 00:36
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private bool playerHitsWave = false;

    [SerializeField]
    private GameObject hitParticle;

    [SerializeField]
    [Range(0.05f, 2f)]
    private float addScoreInterval = 0.2f;
    private float addScoreTimer = 0f;

    [SerializeField]
    private AudioSource waveHitSound;

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag == "Wave")
        {
            if (!waveHitSound.isPlaying) { 
                waveHitSound.Play();
            } else
            {
                waveHitSound.UnPause();
            }
            hitParticle.SetActive(true);
            playerHitsWave = true;
            collider2d.GetComponent<WaveCollision>().BallEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.tag == "Wave")
        {
            waveHitSound.Pause();
            hitParticle.SetActive(false);
            playerHitsWave = false;
            addScoreTimer = 0f;
            collider2d.GetComponent<WaveCollision>().BallExit();
        }
    }

    private void Update()
    {
        if (playerHitsWave)
        {
            addScoreTimer += Time.deltaTime;
            if (addScoreTimer > addScoreInterval)
            {
                ScoreManager.main.AddScoreFromWave();
                addScoreTimer = 0f;
            }
        }
        
    }

    public void ResetPlayer()
    {
        addScoreTimer = 0f;
        hitParticle.SetActive(false);
    }
}
