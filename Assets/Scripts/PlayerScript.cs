//Script: PlayerScript.cs
//Author: Michael Spangenberg
//Purpose: A script to control the player character though keyboard inputs
 


using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    float jump = 10;
    float moveSpeed = 10;
    int jumpCounter = 0;
    int numOfJumps = 2;
    public int acornCounter = 0;
    bool canMove = false;
    public Camera camera;
    

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //Checks key presses for movement
            if (Input.GetKey("d") == true)
            {
                MoveRight();
            }
            if (Input.GetKey("a") == true)
            {
                MoveLeft();
            }
            if (Input.GetKeyDown("space") == true)
            {
                Jump();
            }
        }
        if (camera.transform.position.y <= gameObject.transform.position.y)
        {
            canMove = true;
        }
        
        
    }
    //Moves the player right
    void MoveRight()
    {
        transform.position = transform.position + new Vector3(moveSpeed, 0, 0) * Time.deltaTime * Time.timeScale;
    }
    //Moves player left
    void MoveLeft() {
        transform.position = transform.position + new Vector3(-moveSpeed, 0, 0) * Time.deltaTime * Time.timeScale; 
    }
    //Jumps
    void Jump()
    {
        // if checkJump returns true, jump
        if(checkJump())
        {
            if (jumpCounter < numOfJumps)
            {
                rb.velocity = new Vector2(rb.velocity.x,jump);
                jumpCounter = jumpCounter + 1;
            }
        }
        
        
    }
    //Resets the jumpCounter to zero upon colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
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
}
