using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffWave : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(0.2f, 2f)]
    private float horizontalSpeed = 1f;

    [SerializeField]
    public Puff Puff;
    [SerializeField]
    public Wave Wave;

    [SerializeField]
    private bool isMoving = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isMoving)
        {
            rb2d.velocity = new Vector3(horizontalSpeed, rb2d.velocity.y, 0f);
        }
    }
}
