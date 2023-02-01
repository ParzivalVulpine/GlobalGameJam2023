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

   
    // Update is called once per frame
    void Update()
    {
        //Checks key presses for movement
        if(Input.GetKey("d") == true)
        {
            MoveRight();
        }
        if(Input.GetKey("a") == true){
            MoveLeft();
        }
        if(Input.GetKeyDown("space") == true)
        {
            Jump();
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

    void Jump()
    {
        // if checkJump returns true, jump
        if(checkJump())
        {
            if (jumpCounter < numOfJumps)
            {
                //rb.AddForce(new Vector2(0f, jump));
                rb.velocity = new Vector2(rb.velocity.x,jump);
                jumpCounter = jumpCounter + 1;
            }
            ////Adds additional force to jumps after the first one
            //else
            //{
            //    rb.AddForce(new Vector2(0f, jump*1.1f));
            //    jumpCounter = jumpCounter + 1;
            //}
            
        }
        
        
    }
    //Resets the jumpCounter to zero upon colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
         jumpCounter = 0;
        
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
    
    public int GetAcornCounter()
    {
        return acornCounter;
    }
}
