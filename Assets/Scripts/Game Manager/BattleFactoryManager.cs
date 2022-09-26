using System;
using System.Collections.Generic;
using Character.Base.Data;
using JetBrains.Annotations;
using Tool.Generic;
using UnityEngine;

namespace Game_Manager
{
    public class BattleFactoryManager : Singleton<BattleFactoryManager>
    {
        [Serializable]
        public struct BattleAttribute
        {
            public string _name;
            public CharacterBattleData _data;
        }
        
        public BattleAttribute[] battleAttributes;
        public Dictionary<string, CharacterBattleData> battleDataDict;

        protected override void Awake()
        {
            base.Awake();

            battleDataDict = new Dictionary<string, CharacterBattleData>();
            foreach (var battleAttribute in battleAttributes)
            {
                if (!battleDataDict.ContainsKey(battleAttribute._name))
                {
                    battleDataDict.Add(battleAttribute._name, battleAttribute._data);
                }
            }
        }

        public CharacterBattleData GetBattleData(string name)
        {
            if (battleDataDict.ContainsKey(name))
            {
                return battleDataDict[name];
            }

            Debug.LogError("Can't find" + name + "in factory");
            return default;
        }
    }
}