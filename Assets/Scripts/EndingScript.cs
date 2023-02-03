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
    int acorns;
    public int totalAcorns = 5;
    float timer = 0;
    int seconds;
    int minutes;
    int totalTime;
    public int threeStarTime;
    [SerializeField] bool star1;
    [SerializeField] bool star2;
    [SerializeField] bool star3;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        script = playerObj.GetComponent<PlayerScript>();
        acorns = script.GetAcornCounter();
        //SaveDataManager.instance.Load();
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
        star1 = true;
        //Converts time to seconds
        totalTime = (minutes * 60) + seconds;
        Debug.Log(totalTime);
        Debug.Log(threeStarTime);
        if(totalTime <= threeStarTime)
        {
            star3 = true;
        }
        else
        {
            star3 = false;
            
        }
        //Gets value of the acornCounter variable from the PlayerScript
        acorns = script.GetAcornCounter();
        
        if(acorns == totalAcorns)
        {
            star2 = true;
            
        }
        else
        {
            star2 = false;
            
        }
        if(SaveDataManager.instance.gamedata.savedStar1 != true)
        {
            SaveDataManager.instance.gamedata.savedStar1 = star1;
        }
        if (SaveDataManager.instance.gamedata.savedStar2 != true)
        {
            SaveDataManager.instance.gamedata.savedStar2 = star2;
        }
        if (SaveDataManager.instance.gamedata.savedStar3 != true)
        {
            SaveDataManager.instance.gamedata.savedStar3 = star3;
        }
        SaveDataManager.instance.Save();
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
