using Character.Base.Data;
using Character.Player.Data.Player_Ability_Data;
using Character.Player.Data.Player_Battle_Data;
using Tool.Generic;
using UnityEngine;

namespace Game_Manager
{
    public class GameManager : Singleton<GameManager>
    {
        /*
        [SerializeField] private PlayerAbilityData _abilityData;
        [SerializeField] private PlayerBattleData _battleData;
        */
        
        public PlayerAbilityData AbilityData;
        public PlayerBattleData BattleData;
        public Transform PlayerTransform { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            /*if (!AbilityData)
            {
                Debug.Log(1);
                if (!_abilityData)
                {
                    Debug.LogError("Missing Player Ability Data");
                }
                AbilityData = Instantiate(_abilityData);
            }*/
        }

        public void RegisterPlayer(Transform playerTransform)
        {
            PlayerTransform = playerTransform;
            Debug.Log("Game Manager has registered player");
        }
    }
}