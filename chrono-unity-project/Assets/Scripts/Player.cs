using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    public bool movementEnabled = true;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        if (movementEnabled)
        {
            moveInput = value.Get<Vector2>();
            myRigidbody.velocity = moveInput * 3;
            if (moveInput.y == -1)
            {
                myAnimator.SetBool("Walking Down", true);
            }
            else
            {
                myAnimator.SetBool("Walking Down", false);
            }

            if (moveInput.y == 1)
            {
                myAnimator.SetBool("Walking Up", true);

            }
            else
            {
                myAnimator.SetBool("Walking Up", false);


            }



            if (moveInput.x > 0)
            {
                myAnimator.SetBool("Walking Side", true);
                transform.localScale = new Vector2(1, 1);

            }
            else if (moveInput.x < 0)
            {
                myAnimator.SetBool("Walking Side", true);
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                myAnimator.SetBool("Walking Side", false);
            }

        }
        else
        {
            myRigidbody.velocity = new Vector2(0, 0);

        }


    }

    void Update()
    {


    }
}
