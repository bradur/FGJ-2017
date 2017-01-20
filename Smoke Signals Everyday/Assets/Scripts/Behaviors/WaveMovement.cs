// Date   : 21.01.2017 00:58
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WaveMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(0.2f, 2f)]
    private float horizontalSpeed = 1f;

    private bool startMoving = false;
    private Vector3 originalPosition;

    void Start () {
        originalPosition = transform.position;
        StartMoving();
    }

    public void StartMoving()
    {
        startMoving = true;
    }

    void Update () {
        if (startMoving)
        {
            rb2d.velocity = new Vector3(-horizontalSpeed, 0f, 0f);
            startMoving = false;
        }
        if (Input.GetKey(KeyManager.main.GetKey(Action.ResetWaveDebug)))
        {
            transform.position = originalPosition;
            ScoreManager.main.ResetScore();
        }
    }
}
