using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    private const string PlayerStatsFileName = "/playerStats.dat";
    
    public static void SavePlayerStats()
    {
        PlayerStatsSave save = new PlayerStatsSave();
        save.SetVars(PlayerStats.Instance);
        
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + PlayerStatsFileName;
        FileStream fs = new FileStream(path, FileMode.Create);
        
        bf.Serialize(fs, save);
        fs.Close();
    }
    
    public static PlayerStatsSave LoadPlayerStats()
    {
        string path = Application.persistentDataPath + PlayerStatsFileName;
        PlayerStatsSave save;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            
            try
            {
                save = bf.Deserialize(fs) as PlayerStatsSave;
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load save file: " + e.Message);
                return null;
            }
            
            fs.Close();
            return save;
        }
        else
        {
            save = new PlayerStatsSave();
            return save;
        }
    }
    
    public static void DeletePlayerStats()
    {
        string path = Application.persistentDataPath + PlayerStatsFileName;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
