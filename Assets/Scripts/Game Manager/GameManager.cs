using Character.Base.Data;
using Character.Player.Data.Player_Battle_Data;
using Tool.Generic;
using UnityEngine;

namespace Game_Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public Transform PlayerTransform { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            Random.InitState((int)System.DateTime.Now.Ticks);
        }

        public void RegisterPlayer(Transform playerTransform)
        {
            PlayerTransform = playerTransform;
            Debug.Log("Game Manager has registered player");
        }

        public void RefreshUI(CharacterBattleData battleData)
        {
            UIManager.Instance.RefreshHealthUI(battleData.health);
        }
    }
}