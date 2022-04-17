using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Savemanager
{
    public static string directory = "/SaveData/";
    public static string fileName = "BrainScapeOptionsSave.json";
    
    public static void SaveOptions(OptionsSO so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }
    
    public static OptionsSO Load(OptionsSO so)
    {
        string fullpath = Application.persistentDataPath + directory + fileName;

        if (File.Exists(fullpath))
        {
            string json = File.ReadAllText(fullpath);
            JsonUtility.FromJsonOverwrite(json,so);
        }
        else
        {
            Debug.Log("File not exist");
        }

        return so;
    }
}
