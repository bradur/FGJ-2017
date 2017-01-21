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
    [Range(2f, 50f)]
    private float doubleTapSpeed = 20f;

    private KeyCode moveUp;
    private KeyCode moveDown;

    [SerializeField]
    [Range(0.1f, 0.5f)]
    private float doubleTapInterval = 0.3f;
    [SerializeField]
    [Range(0.3f, 3f)]
    private float doubleTapStayMax = 0.6f;
    private float doubleTapMoveUpTimer = 0f;
    private float doubleTapMoveUpStayTimer = 0f;
    private float doubleTapMoveDownTimer = 0f;
    private float doubleTapMoveDownStayTimer = 0f;

    private int doubleTapMoveUp = 0;
    private int doubleTapMoveDown = 0;

    private bool allowMovement = false;
    public bool AllowMovement { get { return allowMovement; } set { allowMovement = value; } }

    void Start()
    {
        moveUp = KeyManager.main.GetKey(Action.MoveUp);
        moveDown = KeyManager.main.GetKey(Action.MoveDown);
    }

    void Update()
    {

        if (allowMovement)
        {
            if (doubleTapMoveDownTimer < doubleTapInterval)
            {
                doubleTapMoveDownTimer += Time.deltaTime;
            }
            if (doubleTapMoveUpTimer < doubleTapInterval)
            {
                doubleTapMoveUpTimer += Time.deltaTime;
            }
            /*float verticalAxis = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector3(rb2d.velocity.x, verticalAxis * speedForward, 0f);*/


            if (Input.GetKeyDown(moveUp))
            {
                Debug.Log(doubleTapMoveUp);
                if (doubleTapMoveUp > 0)
                {
                    if (doubleTapMoveUpTimer < doubleTapInterval)
                    {
                        rb2d.AddForce(new Vector2(0, doubleTapSpeed), ForceMode2D.Impulse);
                    }
                    doubleTapMoveUp = 0;
                }
                else
                {
                    doubleTapMoveUp++;
                }
                doubleTapMoveUpTimer = 0f;
                doubleTapMoveDown = 0;
            }
            else if (Input.GetKey(moveUp))
            {
                rb2d.AddForce(new Vector2(0, verticalSpeed));
                doubleTapMoveUpStayTimer += Time.deltaTime;
            }
            if (Input.GetKeyUp(moveUp))
            {
                if (doubleTapMoveUpStayTimer > doubleTapStayMax)
                {
                    doubleTapMoveUp = 0;
                }
                doubleTapMoveUpStayTimer = 0f;
                doubleTapMoveUpTimer = 0f;
            }
            if (Input.GetKeyDown(moveDown))
            {
                if (doubleTapMoveDown > 0)
                {
                    if (doubleTapMoveDownTimer < doubleTapInterval)
                    {
                        rb2d.AddForce(new Vector2(0, -doubleTapSpeed), ForceMode2D.Impulse);
                    }
                    doubleTapMoveDown = 0;
                }
                else
                {
                    doubleTapMoveDown++;
                }

                doubleTapMoveDownTimer = 0f;
                doubleTapMoveUp = 0;
            }
            else if (Input.GetKey(moveDown))
            {
                rb2d.AddForce(new Vector2(0, -verticalSpeed));
                doubleTapMoveDownStayTimer += Time.deltaTime;
            }
            if (Input.GetKeyUp(moveDown))
            {
                if (doubleTapMoveDownStayTimer > doubleTapStayMax)
                {
                    doubleTapMoveDown = 0;
                }
                doubleTapMoveDownStayTimer = 0f;
                doubleTapMoveDownTimer = 0f;
            }
        }

    }
}
