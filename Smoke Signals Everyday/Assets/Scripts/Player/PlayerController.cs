// Date   : 20.01.2017 23:32
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb2d;


    [SerializeField]
    [Range(2f, 10f)]
    private float speedForward = 2f;

    [SerializeField]
    [Range(0.2f, 10f)]
    private float verticalSpeed = 0.5f; 

    void Start () {
    
    }

    void Update () {
        /*float verticalAxis = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector3(rb2d.velocity.x, verticalAxis * speedForward, 0f);*/
        if (Input.GetKey(KeyManager.main.GetKey(Action.MoveUp)))
        {
            rb2d.AddForce(new Vector3(0, verticalSpeed, 0f));
        }
        else if (Input.GetKey(KeyManager.main.GetKey(Action.MoveDown)))
        {
            rb2d.AddForce(new Vector3(0, -verticalSpeed, 0f));
        }
    }
}
