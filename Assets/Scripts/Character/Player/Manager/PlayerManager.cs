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
        
        #region Sensor
        
        [SerializeField] private Transform groundSensor;
        [SerializeField] private Transform wallSensor;
        [SerializeField] private Transform ledgeSensor;

        #endregion

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
        
        #endregion

        public PlayerInputHandler Input { get; private set; }

        public Rigidbody2D Rb { get; private set; }
        
        public Animator Anim { get; private set; }
        
        public PlayerAnimatorManager AnimatorManager { get; private set; }

        public int PlayerDirection => transform.localScale.x < 0 ? -1 : 1;

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
            AirState = new PlayerAirState(this, StateMachine, playerData, "inAir");
            LandState = new PlayerLandState(this, StateMachine, playerData, "land");
            WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
            WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
            LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeGrab");
            DashState = new PlayerDashState(this, StateMachine, playerData, "dash");
        }

        public void SetVelocity(Vector2 velocity)
        {
            Rb.velocity = velocity;
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

        public bool CheckLedge()
        {
            bool isTouchingLedge = Physics2D.Raycast(ledgeSensor.position, Vector2.right * PlayerDirection,
                playerData.wallCheckDistance, playerData.groundLayerMask);
            return isTouchingLedge;
        }
        
        #endregion
        
        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinish();
        
        public Vector2 DetermineCornerPosition()
        {
            RaycastHit2D hitX = Physics2D.Raycast(wallSensor.position, Vector2.right * PlayerDirection,
                playerData.wallCheckDistance, playerData.groundLayerMask);
            float distanceX = hitX.distance + 0.01f;
            
            Vector2 detectPosition = (Vector2)ledgeSensor.position + new Vector2(distanceX * PlayerDirection, 0f);
            float detectDistance = ledgeSensor.position.y - wallSensor.position.y;
            RaycastHit2D hitY = Physics2D.Raycast(detectPosition, Vector2.down,
                detectDistance, playerData.groundLayerMask);
            float distanceY = hitY.distance + 0.01f;

            return new Vector2(wallSensor.position.x + distanceX * PlayerDirection, ledgeSensor.position.y - distanceY);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(groundSensor.position, playerData.groundSensorSize);
        }
    }
}
