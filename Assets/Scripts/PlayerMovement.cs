﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Camera cam;
    public GameObject goatSurroundings;

    public float runspeed = 40f;


    float horizontalMove = 0f;
    bool isJumping = false;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        if (horizontalMove != 0)
        {
            myAnimator.SetBool("isMoving", true);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
        }

    }

    private void FixedUpdate()
    {

        cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);

        goatSurroundings.transform.position = transform.position;

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
}
