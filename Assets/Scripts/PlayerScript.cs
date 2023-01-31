using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    bool canJump = true;
    public Rigidbody2D rb;
    float jump = 500;
    // Start is called before the first frame update
    void Start()
    {
        //public Component rb; //= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("d") == true)
        {
            MoveRight();
        }
        else if(Input.GetKey("a") == true){
            MoveLeft();
        }
        if(Input.GetKey("space") == true)
        {
            Jump();
        }
    }
    void MoveRight()
    {
        transform.position = transform.position + new Vector3(20,0,0) * Time.deltaTime* Time.timeScale;
    }
    void MoveLeft() {
        transform.position = transform.position + new Vector3(-20, 0, 0) * Time.deltaTime * Time.timeScale;
    }

    void Jump()
    {
        if(canJump == true)
        {
            rb.AddForce(new Vector2(0f,jump));
        }
        canJump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
