//Script: EndingScript.cs
//Author: Michael Spangenberg
//Purpose: The script handles the end of the game. It checks how many stars the player earned
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Playables;
using JetBrains.Annotations;

public class EndingScript : MonoBehaviour
{
    GameObject playerObj;
    PlayerScript script;
    public GameObject canvas;
    int acorns;
    public int totalAcorns = 3;
    float timer = 0;
    int seconds;
    int minutes;
    int totalTime;
    public int threeStarTime;
    
    SaveData data;
    public string level;
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
    // Checks conditions for stars
    public void Completed()
    {
        
        canvas.SetActive(true);
        script.canMove = false;
        
        //Converts time to seconds
        totalTime = (minutes * 60) + seconds;
        data = SaveDataManager.instance.Load(level);
        if(data == null ) {
            data = new SaveData();    
        }
    
        
        
        data.savedStar1 = true;
        data.level= level;
        
        if (totalTime <= threeStarTime)
        {
            data.savedStar3 = true;
        }
        
        //Gets value of the acornCounter variable from the PlayerScript
        acorns = script.GetAcornCounter();
        
        if(acorns == totalAcorns)
        {
            data.savedStar2 = true;
        }
        SaveDataManager.instance.Save(data);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Completed();
            
        }
    }
}
