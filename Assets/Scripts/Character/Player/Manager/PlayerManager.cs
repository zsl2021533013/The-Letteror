using Character.Core;
using Character.Player.Data;
using Character.Player.Input_System;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Sub_State.Ability_State;
using Character.Player.Player_State.Sub_State.Air_State;
using Character.Player.Player_State.Sub_State.Ground_State;
using Character.Player.Player_State.Sub_State.Wall_State;
using UnityEngine;

namespace Character.Player.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("Player Data")]
        [SerializeField] private PlayerData playerData;

        #region Player FSM Attrbute
        
        public PlayerStateMachine StateMachine { get; private set; }
        
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

        #region Componenets

        public PlayerInputHandler Input { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public Animator Anim { get; private set; }
        public CoreManager CoreManager { get; private set; }

        #endregion
        
        public PlayerAnimatorManager AnimatorManager { get; private set; }
        
        private Vector2 _tempVector2;

        private void Awake()
        {
            InitializeFsm();
            Input = GetComponent<PlayerInputHandler>();
            Rb = GetComponent<Rigidbody2D>();
            Anim = GetComponentInChildren<Animator>();
            AnimatorManager = GetComponentInChildren<PlayerAnimatorManager>();
            AnimatorManager.PlayerManager = this;
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            CoreManager.OnUpdate();
            StateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnFixedUpdate();
        }

        private void InitializeFsm()
        {
            CoreManager = GetComponentInChildren<CoreManager>(); // CoreManager 要在最开始获取
            
            StateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, playerData, "idle");
            MoveState = new PlayerMoveState(this, playerData, "move");
            JumpState = new PlayerJumpState(this, playerData, "inAir");
            AirState = new PlayerAirState(this, playerData, "inAir");
            LandState = new PlayerLandState(this, playerData, "land");
            WallSlideState = new PlayerWallSlideState(this, playerData, "wallSlide");
            WallJumpState = new PlayerWallJumpState(this, playerData, "inAir");
            LedgeClimbState = new PlayerLedgeClimbState(this, playerData, "ledgeGrab");
            DashState = new PlayerDashState(this, playerData, "dash");
            RollState = new PlayerRollState(this, playerData, "roll");
            Attack1State = new PlayerAttack1State(this, playerData, "attack1");
            Attack2State = new PlayerAttack2State(this, playerData, "attack2");
            Attack3State = new PlayerAttack3State(this, playerData, "attack3");
        }

        #region Check Functions

        
        
        #endregion
        
        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinish();

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube( CoreManager.SenseCore.GroundSensor.position, playerData.groundSensorSize);
        }
    }
}
