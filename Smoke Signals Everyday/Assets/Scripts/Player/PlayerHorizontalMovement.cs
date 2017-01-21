// Date   : 21.01.2017 00:58
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHorizontalMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(0.2f, 2f)]
    private float horizontalSpeed = 1f;

    [SerializeField]
    private bool isMoving = false;
    private Vector3 originalPosition;

    void Start () {
        originalPosition = transform.position;
        StartMoving();
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    void Update () {
        if (isMoving)
        {
            rb2d.velocity = new Vector3(horizontalSpeed, rb2d.velocity.y, 0f);
        }
        // DEBUG
        if (Input.GetKey(KeyManager.main.GetKey(Action.ResetWaveDebug)))
        {
            transform.position = originalPosition;
            ScoreManager.main.ResetScore();
            GetComponentInChildren<TrailRenderer>().Clear();
        }
    }
}
