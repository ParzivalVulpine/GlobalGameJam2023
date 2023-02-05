//Script: PlayerScript.cs
//Author: Michael Spangenberg
//Purpose: A script to control the player character though keyboard inputs



using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.UI;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jump = 10;
    public float moveSpeed = 0;
    public int jumpCounter = 0;
    public int numOfJumps = 2;
    public int acornCounter = 0;
    public int accceleration = 5;
    public int maxSpeed = 30;
    public bool canMove = false;
    public Camera camera;
    Vector2 movementControl;
    private bool isFacingRight = true;
    private float horizontal;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //Checks key presses for movement
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            Flip();
        }

        if (camera.transform.position.y <= gameObject.transform.position.y)
        {
            canMove = true;
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * maxSpeed, rb.velocity.y);
    }

    //Jumps
    void Jump()
    {
        // if checkJump returns true, jump
        if (checkJump())
        {
            if (jumpCounter < numOfJumps)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                jumpCounter = jumpCounter + 1;
            }
        }

    }

    //Resets the jumpCounter to zero upon colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "BreakablePlatform")
        {
            jumpCounter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Acorn")
        {
            acornCounter++;
        }



        Destroy(collision.gameObject);
    }
    //Checks if player can jump

    private bool checkJump()
    {
        // If player has not jumped the number of jumps allowed, return true
        if (jumpCounter < numOfJumps)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Gets the value of the acornCounter variable

    public int GetAcornCounter()
    {
        return acornCounter;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
