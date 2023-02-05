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
    public void Save(SaveData data)
    {
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "\\" + data.level +".txt",FileMode.Create);
        serializer.Serialize(stream, data);
        stream.Close();
    }
    public SaveData Load(string filename)
    {
        
        string dataPath = Application.persistentDataPath;
        if(System.IO.File.Exists(dataPath + "\\" + filename + ".txt")){
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "\\" + filename + ".txt", FileMode.Open);
            gamedata = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            hasLoaded = true;
            return gamedata;
        }
        return null;
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
