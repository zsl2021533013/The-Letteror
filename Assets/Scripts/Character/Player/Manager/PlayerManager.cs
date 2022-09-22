using Character.Base.Manager;
using Character.Player.FSM.Player_State.Sub_State.Ability_State;
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
        public PlayerAttack1State Attack1State { get; private set; }
        public PlayerAttack2State Attack2State { get; private set; }
        public PlayerAttack3State Attack3State { get; private set; }
        
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
            Attack1State = new PlayerAttack1State(this, "attack1");
            Attack2State = new PlayerAttack2State(this, "attack2");
            Attack3State = new PlayerAttack3State(this, "attack3");
        }
    }
}
