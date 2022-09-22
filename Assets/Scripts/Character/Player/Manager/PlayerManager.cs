using Character.Base.Manager;
using Character.Player.FSM.Player_State.Sub_State.Ability_State;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Air_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Air_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Ground_Attack;
using Character.Player.FSM.Player_State.Sub_State.Ability_State.Ground_Attack;
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
        public PlayerGroundAttack1State GroundAttack1State { get; private set; }
        public PlayerGroundAttack2State GroundAttack2State { get; private set; }
        public PlayerGroundAttack3State GroundAttack3State { get; private set; }
        public PlayerAirAttackHorizontalState AirAttackHorizontalState { get; private set; }
        public PlayerAirAttackUpState AirAttackUpState { get; private set; }
        public PlayerAirAttackDownState AirAttackDownState { get; private set; }
        
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
            GroundAttack1State = new PlayerGroundAttack1State(this, "attack1");
            GroundAttack2State = new PlayerGroundAttack2State(this, "attack2");
            GroundAttack3State = new PlayerGroundAttack3State(this, "attack3");
            AirAttackHorizontalState = new PlayerAirAttackHorizontalState(this, "attack1");
            AirAttackUpState = new PlayerAirAttackUpState(this, "attack2");
            AirAttackDownState = new PlayerAirAttackDownState(this, "attack1");
        }
    }
}
