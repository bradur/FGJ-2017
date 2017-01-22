// Date   : 22.01.2017 11:47
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

public class PerlinFlicker : MonoBehaviour
{
    [SerializeField]
    private float minPitch = 0.25f;
    [SerializeField]
    private float maxPitch = 0.5f;

    [SerializeField]
    private AudioSource audioSource;

    float random;

    void Start()
    {
        random = Random.Range(0.0f, 65535.0f);
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time);
        audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, noise);
    }
}