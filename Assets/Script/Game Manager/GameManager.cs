using System.Collections.Generic;
using Character.Player.Data.Player_Ability_Data;
using Character.Player.Data.Player_Battle_Data;
using Character.Player.Manager;
using Environment.Parallax;
using Tool.Generic;
using UnityEngine;

namespace Game_Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private PlayerAbilityData _abilityDataTemplate;
        [SerializeField] private PlayerBattleData _battleDataTemplate;

        public List<ParallaxController> parallaxControllers;
        
        public PlayerAbilityData AbilityData;
        public PlayerBattleData BattleData;
        public Transform PlayerTransform { get; private set; }
        public PlayerManager PlayerManager { get; private set; }
        

        protected override void Awake()
        {
            base.Awake();
            
            parallaxControllers.Clear();

            if (!AbilityData)
            {
                InitializedAbilityData();
            }

            if (!BattleData)
            {
                InitializedBattleData();
            }
        }
        
        public void RegisterPlayer(Transform playerTransform)
        {
            PlayerTransform = playerTransform;
            PlayerManager = PlayerTransform.GetComponent<PlayerManager>();
            Debug.Log("Game Manager has registered player");
        }

        public void RegisterParallaxController(ParallaxController parallaxController)
        {
            parallaxControllers.Add(parallaxController);
        }

        public void UpdateParallaxControllers()
        {
            foreach (var parallaxController in parallaxControllers)
            {
                parallaxController.UpdateParallaxController();
            }
        }

        public void EnableDoubleJump()
        { 
            AbilityData.isDoubleJumpEnable = true;
            UpdatePlayerAbilityData();
        }
        
        public void EnableWallSlide()
        { 
            AbilityData.isWallSlideEnable = true;
            UpdatePlayerAbilityData();
        }
        
        public void EnableDash()
        {  
            AbilityData.isDashEnable = true;
            UpdatePlayerAbilityData();
        }
        
        public void EnableSpecialUpwardsAttack()
        { 
            AbilityData.isSpecialUpwardsAttackEnable = true;
            UpdatePlayerAbilityData();
        }
        
        public void EnableSpecialHorizontalAttack()
        {
            AbilityData.isSpecialHorizontalAttackEnable = true;
            UpdatePlayerAbilityData();
        }
        
        public void EnableSpecialDownwardsAttack()
        {
            AbilityData.isSpecialDownwardsAttackEnable = true;
            UpdatePlayerAbilityData();
        }

        private void UpdatePlayerAbilityData() => PlayerManager.UpdateAbilityData(AbilityData);

        public void InitializedAbilityData() => AbilityData = Instantiate(_abilityDataTemplate);

        public void InitializedBattleData() => BattleData = Instantiate(_battleDataTemplate);
    }
}