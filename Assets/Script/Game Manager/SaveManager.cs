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
        private static string BattleDataPath => Application.persistentDataPath + "/Game Save Data/Player Battle Data";
        private static string AbilityDataPath => Application.persistentDataPath + "/Game Save Data/Player Ability Data";

        private static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();

        public static void Save()
        {
            JudgeGameDirectory();
            SavePlayerAbilityData();
            SavePlayerBattleData();
        }

        public static void Load()
        {
            JudgeGameDirectory();
            LoadPlayerAbilityData();
            LoadPlayerBattleData();
        }

        private static void SavePlayerAbilityData()
        {
            FileStream fileStream = File.Create(AbilityDataPath + "/Player Ability Data Save.txt");
            var json = JsonUtility.ToJson(GameManager.Instance.AbilityData, true);
            BinaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
            Debug.Log("Player Ability Data has saved");
        }

        private static void SavePlayerBattleData()
        {
            FileStream fileStream = File.Create(BattleDataPath + "/Player Battle Data Save.txt");
            string json = JsonUtility.ToJson(GameManager.Instance.BattleData, true);
            BinaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
            Debug.Log("Player Battle Data has saved");
        }

        private static void LoadPlayerAbilityData()
        {
            if (File.Exists(AbilityDataPath + "/Player Ability Data Save.txt"))
            {
                FileStream fileStream = File.Open(AbilityDataPath + "/Player Ability Data Save.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)BinaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.AbilityData);
                fileStream.Close();
            }
            else
            {
                GameManager.Instance.InitializedAbilityData();
            }
            Debug.Log("Player Ability Data has loaded");
        }

        private static void LoadPlayerBattleData()
        {
            if (File.Exists(BattleDataPath + "/Player Battle Data Save.txt"))
            {
                FileStream fileStream = File.Open(BattleDataPath + "/Player Battle Data Save.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)BinaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.BattleData);
                fileStream.Close();
            }
            else
            {
                GameManager.Instance.InitializedBattleData();
            }
            GameManager.Instance.PlayerManager.BattleManager.SetBattleData(GameManager.Instance.BattleData);
            Debug.Log("Player Battle Data has loaded");
        }

        private static void JudgeGameDirectory()
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
