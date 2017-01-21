// Date   : 20.01.2017 23:32
// Project: Smoke Signals Everyday
// Author : bradur

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb2d;


    [SerializeField]
    [Range(2f, 10f)]
    private float speedForward = 2f;

    [SerializeField]
    [Range(0.2f, 10f)]
    private float verticalSpeed = 0.5f;

    [SerializeField]
    [Range(10f, 40f)]
    private float nitroSpeed = 10f;

    private KeyCode moveUp;
    private KeyCode moveDown;
    private KeyCode nitroKey;

    private bool allowMovement = false;
    public bool AllowMovement { get { return allowMovement; } set { allowMovement = value; } }

    [SerializeField]
    private TrailRenderer trail;
    public TrailRenderer Trail { get { return trail; } }

    void Start()
    {
        moveUp = KeyManager.main.GetKey(Action.MoveUp);
        moveDown = KeyManager.main.GetKey(Action.MoveDown);
        nitroKey = KeyManager.main.GetKey(Action.Nitro);
    }

    void Update()
    {

        if (allowMovement)
        {
            /*float verticalAxis = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector3(rb2d.velocity.x, verticalAxis * speedForward, 0f);*/
            if (Input.GetKey(moveUp))
            {
                if (Input.GetKey(nitroKey))
                {
                    rb2d.AddForce(new Vector2(0, nitroSpeed));
                } else
                {
                    rb2d.AddForce(new Vector2(0, verticalSpeed));
                }
                
            }
            if (Input.GetKey(moveDown))
            {
                if (Input.GetKey(nitroKey))
                {
                    rb2d.AddForce(new Vector2(0, -nitroSpeed));
                }
                else
                {
                    rb2d.AddForce(new Vector2(0, -verticalSpeed));
                }
            }

        }

    }
}
