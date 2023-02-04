using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    SaveData level1;
    SaveData level2;
    SaveData level3;
    SaveData level4;
    SaveData level5;
    SaveData level6;
    SaveData level7;
    SaveData level8;
    SaveData level9;
    
    // Start is called before the first frame update
    void Start()
    {
        level1 = SaveDataManager.instance.Load("level1");
        level2 = SaveDataManager.instance.Load("level2");
        level3 = SaveDataManager.instance.Load("level3");
        level4 = SaveDataManager.instance.Load("level4");
        level5 = SaveDataManager.instance.Load("level5");
        level6 = SaveDataManager.instance.Load("level6");
        level7 = SaveDataManager.instance.Load("level7");
        level8 = SaveDataManager.instance.Load("level8");
        level9 = SaveDataManager.instance.Load("level9");
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
