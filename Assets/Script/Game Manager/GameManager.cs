using System.Collections;
using Character.Base.Data;
using Character.Player.Data.Player_Ability_Data;
using Script.Character.Player.Input_System;
using Script.Character.Player.Manager;
using Tool.Generic;
using UnityEngine;

namespace Script.Game_Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private PlayerAbilityData _abilityDataTemplate;
        [SerializeField] private CharacterBattleData _battleDataTemplate;

        public PlayerAbilityData AbilityData { get; private set; }
        public CharacterBattleData BattleData { get; private set; }
        public Transform PlayerTransform { get; private set; }
        public PlayerManager PlayerManager { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            if (!AbilityData)
            {
                InitializeAbilityData();
            }

            if (!BattleData)
            {
                InitializeBattleData();
            }
        }
        
        public void RegisterPlayer(Transform playerTransform)
        {
            PlayerTransform = playerTransform;
            PlayerManager = PlayerTransform.GetComponent<PlayerManager>();
            InputHandler = PlayerTransform.GetComponent<PlayerInputHandler>();
            Debug.Log("Game Manager has registered player");
        }

        #region Ability Enable

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
        
        public void EnableSpecialDash()
        {
            AbilityData.isSpecialDashEnable = true;
            UpdatePlayerAbilityData();
        } 

        #endregion

        #region Player Status

        public void ResetHealth() => BattleData.health = _battleDataTemplate.health;
                
        private void UpdatePlayerAbilityData() => PlayerManager.UpdateAbilityData(AbilityData);
                
        public void InitializeAbilityData() => AbilityData = Instantiate(_abilityDataTemplate);
        
        public void InitializeBattleData() => BattleData = Instantiate(_battleDataTemplate);

        #endregion

        public void StopForSeconds(float time)
        {
            StopAllCoroutines();
            StartCoroutine(StopForSecondsIEnumerator(time));
        }

        private IEnumerator StopForSecondsIEnumerator(float time)
        {
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(time);
            Time.timeScale = 1f;
        }
    }
}