using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PixelCrushers;
using Tool.Generic;
using UnityEngine;

namespace Game_Manager
{
    public class SaveManager : Singleton<SaveManager>
    {
        private string BattleDataPath => Application.persistentDataPath + "/Game Save Data/Player Battle Data";
        private string AbilityDataPath => Application.persistentDataPath + "/Game Save Data/Player Ability Data";

        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        public void Save()
        {
            JudgeGameDirectory();
            SavePlayerAbilityData();
        }

        public void Load()
        {
            JudgeGameDirectory();
            LoadPlayerAbilityData();
        }
        
        public void SavePlayerAbilityData()
        {
            FileStream fileStream = File.Create(AbilityDataPath + "/Player Ability Data Save.txt");
            var json = JsonUtility.ToJson(GameManager.Instance.AbilityData, true);
            _binaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
        }

        public void SavePlayerBattleData()
        {
            FileStream fileStream = File.Create(BattleDataPath + "/Player Battle Data Save.txt");
            string json = JsonUtility.ToJson(GameManager.Instance.BattleData, true);
            _binaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
        }
        
        public void LoadPlayerAbilityData()
        {
            if (File.Exists(AbilityDataPath + "/Player Ability Data Save.txt"))
            {
                FileStream fileStream = File.Open(AbilityDataPath + "/Player Ability Data Save.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)_binaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.AbilityData);
                fileStream.Close();
            }
        }
        
        public void LoadPlayerBattleData()
        {
            if (File.Exists(BattleDataPath + "/Player Battle Data Save.txt"))
            {
                FileStream fileStream = File.Open(BattleDataPath + "/Player Battle Data Save.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)_binaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.AbilityData);
                fileStream.Close();
            }
        }

        private void JudgeGameDirectory()
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Game Save Data"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Game Save Data");
            }
            if (!Directory.Exists(BattleDataPath))
            {
                Directory.CreateDirectory(BattleDataPath);
            }
            if (!Directory.Exists(AbilityDataPath))
            {
                Directory.CreateDirectory(AbilityDataPath);
            }
        }
    }
}
