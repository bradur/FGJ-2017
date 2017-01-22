// Date   : 21.01.2017 00:58
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHorizontalMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(0.2f, 2f)]
    private float horizontalSpeed = 1f;

    [SerializeField]
    private TrailRenderer trail;

    [SerializeField]
    private bool isMoving = false;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        //StartMoving();
    }

    public void StartMoving()
    {
        isMoving = true;
        trail.enabled = true;
        trail.Clear();
        trail.gameObject.SetActive(true);
    }

    public void StopMoving()
    {
        isMoving = false;
        rb2d.velocity = Vector2.zero;
        trail.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isMoving)
        {
            rb2d.velocity = new Vector3(horizontalSpeed, rb2d.velocity.y, 0f);
        }

    }
}
