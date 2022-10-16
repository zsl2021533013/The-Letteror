using System;
using System.Collections.Generic;
using Character.Base.Data;
using JetBrains.Annotations;
using Tool.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game_Manager
{
    public class BattleFactoryManager : Singleton<BattleFactoryManager>
    {
        [Serializable]
        public struct BattleAttribute
        {
            public string characterName;
            public CharacterBattleData data;
        }
        
        public BattleAttribute[] battleAttributes;
        public Dictionary<string, CharacterBattleData> battleDataDict;
        
        protected override void Awake()
        {
            base.Awake();

            battleDataDict = new Dictionary<string, CharacterBattleData>();
            foreach (var battleAttribute in battleAttributes)
            {
                if (!battleDataDict.ContainsKey(battleAttribute.characterName))
                {
                    battleDataDict.Add(battleAttribute.characterName, battleAttribute.data);
                }
            }
        }

        public CharacterBattleData GetBattleData(string characterName)
        {
            if (battleDataDict.ContainsKey(characterName))
            {
                return battleDataDict[characterName];
            }

            Debug.LogError("Can't find " + characterName + " in factory");
            return default;
        }
    }
}