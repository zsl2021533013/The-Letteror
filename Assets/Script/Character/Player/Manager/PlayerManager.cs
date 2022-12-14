using Character.Base.Manager;
using Character.Player.Core.Core_Manager;
using Character.Player.Data.Player_Ability_Data;
using Character.Player.Data.Player_Battle_Data;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Air_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Air_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Ground_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack;
using Game_Manager;
using Script.Character.Player.FSM.Player_State.Sub_State.Ability_State;
using Script.Character.Player.FSM.Player_State.Sub_State.Air_State;
using Script.Character.Player.FSM.Player_State.Sub_State.Ground_State;
using Script.Character.Player.FSM.Player_State.Sub_State.Wall_State;
using Script.Character.Player.Input_System;
using Script.Environment.Camera;
using Script.Game_Manager;
using UnityEngine;

namespace Script.Character.Player.Manager
{
    public class PlayerManager : CharacterManager
    {
        public PlayerAbilityData AbilityData { get; private set; }
        public PlayerBattleData BattleData { get; private set; }
        public PlayerUIManager UIManager { get; private set; }
        public PlayerInputHandler Input { get; private set; }
        public new PlayerCoreManager CoreManager { get; private set; }

        #region Player FSM Attribute
        
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerAirState AirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerWallJumpState WallJumpState { get; private set; }
        public PlayerLedgeClimbState LedgeClimbState { get; private set; }
        public PlayerDashState DashState { get; private set; }
        public PlayerSpecialDashState SpecialDashState { get; private set; }
        public PlayerGainAbilityState GainAbilityState { get; private set; }
        public PlayerDeathState DeathState { get; private set; }

        #region Attack State
        
        public PlayerGroundAttack1State GroundAttack1State { get; private set; }
        public PlayerGroundAttack2State GroundAttack2State { get; private set; }
        public PlayerGroundUpwardsAttackState GroundUpwardsAttackState { get; private set; } 
        public PlayerAirHorizontalAttack1State AirHorizontalAttack1State { get; private set; }
        public PlayerAirHorizontalAttack2State AirHorizontalAttack2State { get; private set; }
        public PlayerAirUpwardsAttackState AirUpwardsAttackState { get; private set; }
        public PlayerAirDownwardsAttackState AirDownwardsAttackState { get; private set; }
        public PlayerSpecialDashAttackState SpecialDashAttackState { get; private set; }
        public PlayerSpecialUpwardsAttackState SpecialUpwardsAttackState { get; private set; }
        public PlayerSpecialDownwardsAttack1State SpecialDownwardsAttack1State { get; private set; }
        public PlayerSpecialDownwardsAttack2State SpecialDownwardsAttack2State { get; private set; }
        public PlayerSpecialDownwardsAttack3State SpecialDownwardsAttack3State { get; private set; }
        
        #endregion
        
        #endregion

        protected override void Awake()
        {
            base.Awake();

            Input = GetComponent<PlayerInputHandler>();
            CoreManager = (PlayerCoreManager)base.CoreManager;
        }

        protected override void Start()
        {
            base.Start();

            UIManager = PlayerUIManager.Instance;
            
            GameManager.Instance.RegisterPlayer(transform);
            
            StateMachine.Initialize(IdleState);

            if (!UIManager)
            {
                Debug.LogError("Missing UI Manager");
            }
            
            AbilityData = GameManager.Instance.AbilityData;
            BattleData = (PlayerBattleData)GameManager.Instance.BattleData;
            BattleManager.SetBattleData(GameManager.Instance.BattleData);
        }

        protected override void Update()
        {
            base.Update();

            if (CoreManager.SenseCore.DetectTrigger && StateMachine.CurrentState is not PlayerDeathState)
            {
                CoreManager.SenseCore.GetTrigger().Interact(this);
            }

            if (Input.SelectWindowInput)
            {
                Input.ResetSelectWindowInput();
                UIManager.OpenOrCloseSelectWindow();
            }
        }

        protected override void InitializeFSM()
        {
            base.InitializeFSM();
            
            IdleState = new PlayerIdleState(this, "idle");
            MoveState = new PlayerMoveState(this, "move");
            JumpState = new PlayerJumpState(this, "inAir");
            AirState = new PlayerAirState(this, "inAir");
            LandState = new PlayerLandState(this, "land");
            WallSlideState = new PlayerWallSlideState(this, "wallSlide");
            WallJumpState = new PlayerWallJumpState(this, "inAir");
            LedgeClimbState = new PlayerLedgeClimbState(this, "ledgeGrab");
            DashState = new PlayerDashState(this, "dash");
            SpecialDashState = new PlayerSpecialDashState(this, "specialDash");
            GainAbilityState = new PlayerGainAbilityState(this, "gainAbility");
            DeathState = new PlayerDeathState(this, "death");

            #region Attack State 
            
            GroundAttack1State = new PlayerGroundAttack1State(this, "groundAttack1");
            GroundAttack2State = new PlayerGroundAttack2State(this, "groundAttack2");
            GroundUpwardsAttackState = new PlayerGroundUpwardsAttackState(this, "groundUpwardsAttack");
            AirHorizontalAttack1State = new PlayerAirHorizontalAttack1State(this, "airHorizontalAttack1");
            AirHorizontalAttack2State = new PlayerAirHorizontalAttack2State(this, "airHorizontalAttack2");
            AirUpwardsAttackState = new PlayerAirUpwardsAttackState(this, "airUpwardsAttack");
            AirDownwardsAttackState = new PlayerAirDownwardsAttackState(this, "airDownwardsAttack");
            SpecialDashAttackState = new PlayerSpecialDashAttackState(this, "specialHorizontalAttack");
            SpecialUpwardsAttackState = new PlayerSpecialUpwardsAttackState(this, "specialUpwardsAttack");
            SpecialDownwardsAttack1State = new PlayerSpecialDownwardsAttack1State(this, "specialDownwardsAttack1");
            SpecialDownwardsAttack2State = new PlayerSpecialDownwardsAttack2State(this, "specialDownwardsAttack2");
            SpecialDownwardsAttack3State = new PlayerSpecialDownwardsAttack3State(this, "specialDownwardsAttack3");
            
            #endregion
        }

        public void ResetAbility()
        {
            JumpState.ResetAmountOfJump();
            DashState.ResetAmountOfDash();
            SpecialDashAttackState.ResetAmountOfSpecialAttack();
            SpecialUpwardsAttackState.ResetAmountOfSpecialAttack();
            SpecialDownwardsAttack1State.ResetAmountOfSpecialAttack();
        }

        public override void TryToDamage(CharacterBattleManager targetBattleManager)
        {
            base.TryToDamage(targetBattleManager);

            if (StateMachine.CurrentState == AirDownwardsAttackState)
            {
                CoreManager.MoveCore.SetVelocityY(CoreManager.MoveCore.StateMachineData.airDownwardsAttackVelocityY);
            }
            
            CoreManager.BattleEffectCore.ShakeCamera(CoreManager.BattleEffectCore.attackCameraShakeIntensity, CoreManager.BattleEffectCore.cameraShakeTime);
            
            CoreManager.BattleEffectCore.StopForSeconds(CoreManager.BattleEffectCore.attackPauseTime);
        }

        public override void Damaged()
        {
            base.Damaged();
            
            UIManager.RefreshHealthUI(GameManager.Instance.BattleData.health);
            
            BattleManager.StartImmortalForSeconds(CoreManager.BattleEffectCore.immortalTimeAfterDamaged);
            BattleManager.Flash();

            CoreManager.BattleEffectCore.ShakeCamera(CoreManager.BattleEffectCore.damagedCameraShakeIntensity, CoreManager.BattleEffectCore.cameraShakeTime);
            
            CoreManager.BattleEffectCore.StopForSeconds(CoreManager.BattleEffectCore.damagedPauseTime);
        }

        public override void Die()
        {
            base.Die();
            
            UIManager.RefreshHealthUI(GameManager.Instance.BattleData.health);
        }

        public void CloseHUD()
        {
            UIManager.CloseHUD();
        }

        public void OpenHUD()
        {
            UIManager.OpenHUD();
        } // ???????????????????????????

        public void UpdateAbilityData(PlayerAbilityData abilityData) => AbilityData = abilityData;
    }
}
