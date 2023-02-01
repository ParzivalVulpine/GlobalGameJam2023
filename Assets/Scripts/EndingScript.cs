//Script: EndingScript.cs
//Author: Michael Spangenberg
//Purpose: The script handles the end of the game. It checks how many stars the player earned
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndingScript : MonoBehaviour
{
    GameObject playerObj;
    PlayerScript script;
    int acorns;
    public int totalAcorns;
    float timer = 0;
    int seconds;
    int minutes;
    int totalTime;
    public int threeStarTime;
    bool star1;
    bool star2;
    bool star3;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        script = playerObj.GetComponent<PlayerScript>();
        acorns = script.GetAcornCounter();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer counts in minutes and seconds
        timer = timer + Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60); 
        seconds = Mathf.FloorToInt(timer % 60);
        
        
    }
    public void Completed()
    {
        
        // Checks conditions for stars
        star1 = true;
        //Converts time to seconds
        totalTime = (minutes * 60) + seconds;
        if(totalTime <= threeStarTime)
        {
            star3 = true;
        }
        else
        {
            star3 = false;
            
        }
        acorns = script.GetAcornCounter();
        
        if(acorns == totalAcorns)
        {
            star2 = true;
            
        }
        else
        {
            star2 = false;
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Completed();
        }
    }
    public bool GetStar1()
    {
        return star1;
    }
    public bool GetStar2()
    {
        return star2;
    }
    public bool GetStar3()
    {
        return star3;
    }
}
