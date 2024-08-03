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
    
    public static void LoadPlayerStats()
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
                return;
            }
            
            save!.GetVars(PlayerStats.Instance);
            fs.Close();
        }
        else
        {
            save = new PlayerStatsSave();
            save.GetVars(PlayerStats.Instance);
        }
    }
}
