using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndingScript : MonoBehaviour
{
    int acornCounter = 0;
    int totalAcorns = 10;
    int timer = 0;
    int threeStarTime;
    bool star1;
    bool star2;
    bool star3;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Completed()
    {
        star1 = true;
        if(timer < threeStarTime)
        {
            star3 = true;
        }
        else
        {
            star3 = false;
        }
        if(acornCounter == totalAcorns)
        {
            star2 = true;
        }
        else
        {
            star2 = false;
        }
    }
    public void IncrementAcorn()
    {
        acornCounter++;
    }
}
