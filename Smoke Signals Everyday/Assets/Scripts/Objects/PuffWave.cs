﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffWave : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    [Range(-10f, 0.5f)]
    private float horizontalSpeed = 1f;

    [SerializeField]
    public Puff Puff;
    [SerializeField]
    public Wave Wave;
    [SerializeField]
    public AnimPuff AnimPuff;

    [SerializeField]
    private Wave littleWave;
    public Wave LittleWave { get { return littleWave; } set { littleWave = value; } }

    [SerializeField]
    private bool isMoving = false;

    public void PuffAnimOut()
    {
        AnimPuff.GetComponent<Animator>().SetTrigger("PuffFadeOut");
    }

    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }

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
        else
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    public void SetAnim(AnimPuff anim)
    {
        AnimPuff = anim;
    }
}
