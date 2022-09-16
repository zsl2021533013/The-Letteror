using System;
using Character.Player.Data;
using Character.Player.Input_System;
using Character.Player.Manager;
using Character.Player.Player_State.Sub_State;
using Character.Player.Player_State.Super_State;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character.Player.Player_FSM
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("Player Data")]
        [SerializeField] private PlayerData playerData;
        
        #region Sensor
        
        [SerializeField] private Transform groundSensor;
        [SerializeField] private Transform wallSensor;

        #endregion

        #region Player FSM Attrbute
        
        public PlayerStateMachine StateMachine { get; private set; }
        
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerWallGrabState WallGrabState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerWallJumpState WallJumpState { get; private set; }
        
        #endregion

        public InputHandler Input { get; private set; }

        public Rigidbody2D Rb { get; private set; }
        
        public Animator Anim { get; private set; }
        
        public PlayerAnimatorManager AnimatorManager { get; private set; }

        public int PlayerDirection => transform.localScale.x < 0 ? -1 : 1;

        private void Awake()
        {
            InitializeFsm();
            Input = GetComponent<InputHandler>();
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
            StateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnFixedUpdate();
        }

        private void InitializeFsm()
        {
            StateMachine = new PlayerStateMachine();
            IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
            InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
            LandState = new PlayerLandState(this, StateMachine, playerData, "land");
            WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
            WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
            WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        }

        public void SetVelocity(float velocity, Vector2 angle,int direction)
        {
            angle.Normalize();
            Rb.velocity = new Vector2(velocity * angle.x * direction, velocity * angle.y);
        }
        
        public void SetVelocityX(float velocityX)
        {
            Rb.velocity = new Vector2(velocityX, Rb.velocity.y);
        }
        
        public void SetVelocityY(float velocityY)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, velocityY);
        }

        #region Check Functions
        
        public void CheckPlayerFlip()
        {
            if (Input.MovementInput.x != 0f && Input.InputDirection == -PlayerDirection)
            {
                transform.localScale = new Vector3(Input.InputDirection, 1, 1);
            }
        }

        public bool CheckGrounded()
        {
            bool isGrounded = Physics2D.OverlapBox(groundSensor.position, playerData.groundSensorSize, 0f,
                playerData.groundLayerMask);
            return isGrounded;
        }

        public bool CheckWall()
        {
            bool isTouchingWall = Physics2D.Raycast(wallSensor.position, Vector2.right * PlayerDirection,
                playerData.wallCheckDistance, playerData.groundLayerMask);
            return isTouchingWall;
        }

        #endregion

        public void AnimationTrigger() => StateMachine.CurrentState.AnimatonTrigger();

        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinish();
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(groundSensor.position, playerData.groundSensorSize);
        }
    }
}
