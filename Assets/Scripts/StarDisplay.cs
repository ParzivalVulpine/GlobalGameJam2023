using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    SaveData level1;
    SaveData level2;
    SaveData level3;
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    Text l1t;
    Text l2t;
    Text l3t;
    bool starsDisplayed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        level1 = SaveDataManager.instance.Load("level1");
        level2 = SaveDataManager.instance.Load("level2");
        level3 = SaveDataManager.instance.Load("level3");
        
    }
    

    
    public void ShowStars()
    {
        if(starsDisplayed == false)
        {
            if(level1 != null)
            {
                l1t = l1.gameObject.GetComponent<Text>();
                l1t.text = l1t.text + level1.savedStar1 + ", " + level1.savedStar1 + ", " + level1.savedStar3;
            }
            if(level2 != null)
            {
                l2t = l2.gameObject.GetComponent<Text>();
                l2t.text = l2t.text + level2.savedStar1 + ", " + level2.savedStar2 + ", " + level2.savedStar3;
            }

            if(level3 != null)
            {
                l3t = l3.gameObject.GetComponent<Text>();
                l3t.text = l3t.text + level3.savedStar1 + ", " + level3.savedStar2 + ", " + level3.savedStar3;
            }
            starsDisplayed = true;
        }
        
        



    }
}
