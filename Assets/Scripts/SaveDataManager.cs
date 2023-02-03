using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager instance;
    public SaveData gamedata = new SaveData();
    public bool hasLoaded;
    
    private void Awake()
    {
        instance = this;
        
        
    }
    public void Save()
    {
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "\\" + gamedata.level +".txt",FileMode.Create);
        serializer.Serialize(stream, gamedata);
        stream.Close();
    }
    public void Load(string filename)
    {
        string dataPath = Application.persistentDataPath;
        Debug.Log(dataPath + '\\' + filename + ".txt");
        if(System.IO.File.Exists(dataPath + "\\" + filename + ".txt")){
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "\\" + filename + ".txt", FileMode.Open);
            gamedata = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            hasLoaded = true;
        }
    }
    public void Delete()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "\\" + gamedata.level + ".txt"))
        {
            File.Delete(dataPath + "\\" + gamedata.level + ".txt");
        }
    }
    
}
[System.Serializable]
public class SaveData
{
    public string level;
    public bool savedStar1;
    public bool savedStar2;
    public bool savedStar3;
}
