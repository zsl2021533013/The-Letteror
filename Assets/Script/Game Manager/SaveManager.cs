using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PixelCrushers;
using Script.Game_Manager;
using Tool.Generic;
using UnityEngine;

namespace Game_Manager
{
    public class SaveManager : Singleton<SaveManager>
    {
        private static string SaveDataDictionaryPath => Application.persistentDataPath + "/Game Save Data";
        private static string BattleDataDictionaryPath => SaveDataDictionaryPath + "/Player Battle Data";
        private static string AbilityDataDictionaryPath => SaveDataDictionaryPath + "/Player Ability Data";
        private static string BattleDataFilePath => BattleDataDictionaryPath + "/Player Battle Data Save.txt";
        private static string AbilityDataFilePath => AbilityDataDictionaryPath + "/Player Ability Data Save.txt";

        private static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();

        private static bool _skipSavingOnce; // 防止玩家死亡时由于加载场景保存游戏
        
        public static void Save()
        {
            if (_skipSavingOnce)
            {
                _skipSavingOnce = false;
                return;
            }
            
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

        public static void InitializeData()
        {
            GameManager.Instance.InitializeAbilityData();
            GameManager.Instance.InitializeBattleData();

            JudgeGameDirectory();
            SavePlayerAbilityData();
            SavePlayerBattleData();
        }

        private static void SavePlayerAbilityData()
        {
            FileStream fileStream = File.Create(AbilityDataFilePath);
            var json = JsonUtility.ToJson(GameManager.Instance.AbilityData, true);
            BinaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
            Debug.Log("Player Ability Data has saved");
        }

        private static void SavePlayerBattleData()
        {
            FileStream fileStream = File.Create(BattleDataFilePath);
            string json = JsonUtility.ToJson(GameManager.Instance.BattleData, true);
            BinaryFormatter.Serialize(fileStream, json);
            fileStream.Close();
            Debug.Log("Player Battle Data has saved");
        }

        private static void LoadPlayerAbilityData()
        {
            if (File.Exists(AbilityDataFilePath))
            {
                FileStream fileStream = File.Open(AbilityDataFilePath, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)BinaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.AbilityData);
                fileStream.Close();
            }
            else
            {
                GameManager.Instance.InitializeAbilityData();
                SavePlayerAbilityData();
            }
            Debug.Log("Player Ability Data has loaded");
        }

        private static void LoadPlayerBattleData()
        {
            if (File.Exists(BattleDataFilePath))
            {
                FileStream fileStream = File.Open(BattleDataFilePath, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)BinaryFormatter.Deserialize(fileStream),
                    GameManager.Instance.BattleData);
                fileStream.Close();
            }
            else
            {
                GameManager.Instance.InitializeBattleData();
                SavePlayerBattleData();
            }
            GameManager.Instance.PlayerManager.BattleManager.SetBattleData(GameManager.Instance.BattleData);
            Debug.Log("Player Battle Data has loaded");
        }

        private static void JudgeGameDirectory()
        {
            if (!Directory.Exists(SaveDataDictionaryPath))
            {
                Directory.CreateDirectory(SaveDataDictionaryPath);
            }
            if (!Directory.Exists(BattleDataDictionaryPath))
            {
                Directory.CreateDirectory(BattleDataDictionaryPath);
            }
            if (!Directory.Exists(AbilityDataDictionaryPath))
            {
                Directory.CreateDirectory(AbilityDataDictionaryPath);
            }
        }

        public static bool ExistFile()
        {
            return (File.Exists(BattleDataFilePath) && File.Exists(AbilityDataFilePath));
        }

        public static void SkipSaving() => _skipSavingOnce = true;
    }
}
