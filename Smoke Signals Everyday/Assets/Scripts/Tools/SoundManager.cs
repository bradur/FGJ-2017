using UnityEngine;
using System.Collections.Generic;

public enum SoundType
{
    None
}

public class SoundManager : MonoBehaviour {

    public static SoundManager main;

    [SerializeField]
    private List<GameSound> sounds = new List<GameSound>();
    private RandomWrapper rng;

    private bool isOn = true;

    void Awake()
    {
        main = this;
        rng = new RandomWrapper();
    }
    
    public void PlaySound(SoundType soundType)
    {
        if (isOn) { 
            foreach(GameSound gameSound in sounds)
            {
                if(gameSound.soundType == soundType)
                {
                    rng.Choose(gameSound.sounds).Play();
                }
            }
        }
    }

    public bool Toggle()
    {
        isOn = !isOn;
        return isOn;
    }
}

[System.Serializable]
public class GameSound : System.Object
{
    
    public SoundType soundType;
    public List<AudioSource> sounds = new List<AudioSource>();

}