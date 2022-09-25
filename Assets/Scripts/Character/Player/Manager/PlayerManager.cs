using Character.Base.Manager;
using Character.Player.FSM.Player_State.Sub_State.Ability_State;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Air_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Air_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Ground_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack;
using Character.Player.FSM.Player_State.Sub_State.Air_State;
using Character.Player.FSM.Player_State.Sub_State.Ground_State;
using Character.Player.FSM.Player_State.Sub_State.Wall_State;
using Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.Manager
{
    public class PlayerManager : CharacterManager
    {
        [Header("Player Ability Active")] 
        public bool isDoubleJumpEnable;
        public bool isWallSlideEnable;
        public bool isDashEnable;
        
        public PlayerInputHandler Input { get; private set; }
        
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
        public PlayerRollState RollState { get; private set; }
        public PlayerDamagedState DamagedState { get; private set; }
        public PlayerDeathState DeathState { get; private set; }

        #region Attack State
        
        public PlayerGroundAttack1State GroundAttack1State { get; private set; }
        public PlayerGroundAttack2State GroundAttack2State { get; private set; }
        public PlayerGroundUpwardsAttackState GroundUpwardsAttackState { get; private set; } 
        public PlayerAirHorizontalAttack1State AirHorizontalAttack1State { get; private set; }
        public PlayerAirHorizontalAttack2State AirHorizontalAttack2State { get; private set; }
        public PlayerAirUpwardsAttackState AirUpwardsAttackState { get; private set; }
        public PlayerAirDownwardsAttackState AirDownwardsAttackState { get; private set; }
        public PlayerSpecialIdleAttackState SpecialIdleAttackState { get; private set; }
        public PlayerSpecialDashAttackState SpecialDashAttackState { get; private set; }
        public PlayerSpecialUpwardsAttackState SpecialUpwardsAttackState { get; private set; }
        public PlayerSpecialDownwardsAttackState SpecialDownwardsAttackState { get; private set; }
        
        #endregion
        
        #endregion
        
        
        protected override void Awake()
        {
            base.Awake();

            Input = GetComponent<PlayerInputHandler>();
        }

        protected override void Start()
        {
            base.Start();
            
            StateMachine.Initialize(IdleState);
        }

        protected override void InitializeFsm()
        {
            base.InitializeFsm();
            
            IdleState = new PlayerIdleState(this, "idle");
            MoveState = new PlayerMoveState(this, "move");
            JumpState = new PlayerJumpState(this, "inAir");
            AirState = new PlayerAirState(this, "inAir");
            LandState = new PlayerLandState(this, "land");
            WallSlideState = new PlayerWallSlideState(this, "wallSlide");
            WallJumpState = new PlayerWallJumpState(this, "inAir");
            LedgeClimbState = new PlayerLedgeClimbState(this, "ledgeGrab");
            DashState = new PlayerDashState(this, "dash");
            RollState = new PlayerRollState(this, "roll");
            DamagedState = new PlayerDamagedState(this, "damaged");
            DeathState = new PlayerDeathState(this, "death");

            #region Attack State 
            
            GroundAttack1State = new PlayerGroundAttack1State(this, "groundAttack1");
            GroundAttack2State = new PlayerGroundAttack2State(this, "groundAttack2");
            GroundUpwardsAttackState = new PlayerGroundUpwardsAttackState(this, "groundUpwardsAttack");
            AirHorizontalAttack1State = new PlayerAirHorizontalAttack1State(this, "airHorizontalAttack1");
            AirHorizontalAttack2State = new PlayerAirHorizontalAttack2State(this, "airHorizontalAttack2");
            AirUpwardsAttackState = new PlayerAirUpwardsAttackState(this, "airUpwardsAttack");
            AirDownwardsAttackState = new PlayerAirDownwardsAttackState(this, "airDownwardsAttack");
            SpecialIdleAttackState = new PlayerSpecialIdleAttackState(this, "groundAttack1");
            SpecialDashAttackState = new PlayerSpecialDashAttackState(this, "groundAttack1");
            SpecialUpwardsAttackState = new PlayerSpecialUpwardsAttackState(this, "groundAttack1");
            SpecialDownwardsAttackState = new PlayerSpecialDownwardsAttackState(this, "groundAttack1");

            #endregion
        }

        public void ResetJumpAndDash()
        {
            JumpState.ResetAmountOfJump();
            DashState.ResetAmountOfDash();
        }

        public override void GetHit()
        {
            base.GetHit();
            
            StateMachine.TranslateToState(DamagedState);
        }

        public override void Die()
        {
            base.Die();
            
            StateMachine.TranslateToState(DeathState);
        }
    }
}
