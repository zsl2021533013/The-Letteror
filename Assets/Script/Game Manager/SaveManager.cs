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
            SavePlayerBattleData();
        }

        public void Load()
        {
            JudgeGameDirectory();
            LoadPlayerAbilityData();
            LoadPlayerBattleData();
        }

        private void SavePlayerAbilityData()
        {
            FileStream fileStream = File.Create(AbilityDataPath + "/Player Ability Data Save.txt");
            var json = JsonUtility.ToJson(GameManager.Instance.AbilityData, true);
            _binaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
            Debug.Log("Player Ability Data has saved");
        }

        private void SavePlayerBattleData()
        {
            FileStream fileStream = File.Create(BattleDataPath + "/Player Battle Data Save.txt");
            string json = JsonUtility.ToJson(GameManager.Instance.BattleData, true);
            _binaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
            Debug.Log("Player Battle Data has saved");
        }

        private void LoadPlayerAbilityData()
        {
            if (File.Exists(AbilityDataPath + "/Player Ability Data Save.txt"))
            {
                FileStream fileStream = File.Open(AbilityDataPath + "/Player Ability Data Save.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)_binaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.AbilityData);
                fileStream.Close();
            }
            else
            {
                GameManager.Instance.InitializedAbilityData();
            }
            Debug.Log("Player Ability Data has loaded");
        }

        private void LoadPlayerBattleData()
        {
            if (File.Exists(BattleDataPath + "/Player Battle Data Save.txt"))
            {
                FileStream fileStream = File.Open(BattleDataPath + "/Player Battle Data Save.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)_binaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.BattleData);
                fileStream.Close();
            }
            else
            {
                GameManager.Instance.InitializedBattleData();
            }
            Debug.Log("Player Battle Data has loaded");
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
