using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class dataManager : MonoBehaviour
{
    public playerData data;
    private string file = "playerData.txt";
    // Start is
    // called before the first frame update
    void Start()
    {
        
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
    public void save()
    {
        string json = JsonUtility.ToJson(data);
        writeToFile(file, json);
    }

    public void load()
    {
        data = new playerData();
        string json = readFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }
    private void writeToFile(string filename,string json)
    {
        string path = GetFilePath(filename);
        FileStream file= new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.Write(json);
        }
    }
    private string readFromFile(string filename)
    {
        string path = GetFilePath(filename);
        if(File.Exists(path))
        {
            using (StreamReader reader =new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.Log("file not found!");
        }
        return "";
    }
    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }
}
