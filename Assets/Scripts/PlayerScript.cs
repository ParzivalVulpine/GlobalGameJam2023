//Script: PlayerScript.cs
//Author: Michael Spangenberg
//Purpose: A script to control the player character though keyboard inputs
//Todo List: 


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    bool sprinting = false;
    public Rigidbody2D rb;
    float jump = 500;
    float moveSpeed = 10;
    float sprintSpeed = 10;
    int jumpCounter = 0;
    int numOfJumps = 2;

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
        //if (Input.GetKey("left shift") == true)
        //{
        //    sprinting = true;
        //}
        //else
        //{
        //    sprinting = false;
        //}
    }
    //Moves the player right
    void MoveRight()
    {
        // If player is sprinting
        if(sprinting == true)
        {
            transform.position = transform.position + new Vector3(moveSpeed+sprintSpeed, 0, 0) * Time.deltaTime * Time.timeScale;

        }
        //If player is not sprinting
        else
        {
            transform.position = transform.position + new Vector3(moveSpeed, 0, 0) * Time.deltaTime * Time.timeScale;

        }
    }
    //Moves player left
    void MoveLeft() {
        //If player is sprinting
        if (sprinting == true)
        {
            transform.position = transform.position + new Vector3(-moveSpeed + -sprintSpeed, 0, 0) * Time.deltaTime * Time.timeScale;

        }
        //If player is not sprinting
        else
        {
            transform.position = transform.position + new Vector3(-moveSpeed, 0, 0) * Time.deltaTime * Time.timeScale;

        }
    }

    void Jump()
    {
        // if checkJump returns true, jump
        if(checkJump())
        {
            if (jumpCounter == 0)
            {
                rb.AddForce(new Vector2(0f, jump));
                jumpCounter = jumpCounter + 1;
            }
            //Adds additional force to jumps after the first one
            else
            {
                rb.AddForce(new Vector2(0f, jump*2));
                jumpCounter = jumpCounter + 1;
            }
            
        }
        
        
    }
    //Resets the jumpCounter to zero upon colliding with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCounter = 0;
    }
    //Checks if player can jump
    private bool checkJump()
    {
        // If player has not jumped twice, return true
        if (jumpCounter < numOfJumps)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
