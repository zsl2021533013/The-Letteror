using Character.Base.Data;
using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.Core.Core_Manager;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Teleport_State;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.Manager
{
    public class BloodKingManager : CharacterManager
    {
        public GameObject HeartPrefab;
        
        public BoxCollider2D Collider2D { get; private set; }
        public int CurrentState { get; private set; }
        
        protected new BloodKingCoreManager CoreManager { get; private set; }
        #region FSM Component
        
        public BloodKingIdleState IdleState { get; private set; }
        public BloodKingBlueIdleState BlueIdleState { get; private set; }
        public BloodKingAppearCloserState AppearCloserState { get; private set; }
        public BloodKingAppearFartherState AppearFartherState { get; private set; }
        public BloodKingDisappearCloserState DisappearCloserState { get; private set; }
        public BloodKingDisappearFartherState DisappearFartherState { get; private set; }
        
        public BloodKingBlueChaseState BlueChaseState { get; private set; }
        public BloodKingTransform1State Transform1State { get; private set; }
        public BloodKingTransform2State Transform2State { get; private set; }
        public BloodKingDeathState DeathState { get; private set; }

        #region Attack State

        public BloodKingAttack1State Attack1State { get; private set; }
        public BloodKingAttack2State Attack2State { get; private set; }
        public BloodKingAttack3State Attack3State { get; private set; }
        public BloodKingAttack4State Attack4State { get; private set; }
        public BloodKingJumpAttackState JumpAttackState { get; private set; }
        public BloodKingBlueAttackState BlueAttackState { get; private set; }

        #endregion
        
        #endregion

        protected override void Awake()
        {
            base.Awake();

            Collider2D = GetComponent<BoxCollider2D>();
            CoreManager = (BloodKingCoreManager)base.CoreManager;
        }

        protected override void Start()
        {
            base.Start();

            CurrentState = 0;
            
            StateMachine.Initialize(Transform2State);
        }

        protected override void InitializeFSM()
        {
            base.InitializeFSM();

            IdleState = new BloodKingIdleState(this, "idle");
            BlueIdleState = new BloodKingBlueIdleState(this, "blueIdle");
            BlueChaseState = new BloodKingBlueChaseState(this, "blueChase");
            AppearCloserState = new BloodKingAppearCloserState(this, "appear");
            AppearFartherState = new BloodKingAppearFartherState(this, "appear");
            DisappearCloserState = new BloodKingDisappearCloserState(this, "disappear");
            DisappearFartherState = new BloodKingDisappearFartherState(this, "disappear");
            Transform1State = new BloodKingTransform1State(this, "transform1");
            Transform2State = new BloodKingTransform2State(this, "transform2");
            DeathState = new BloodKingDeathState(this, "death");
            
            Attack1State = new BloodKingAttack1State(this, "attack1");
            Attack2State = new BloodKingAttack2State(this, "attack2");
            Attack3State = new BloodKingAttack3State(this, "attack3");
            Attack4State = new BloodKingAttack4State(this, "attack4");
            BlueAttackState = new BloodKingBlueAttackState(this, "blueAttack");
            JumpAttackState = new BloodKingJumpAttackState(this, "jumpAttack");
        }

        public override void Damaged()
        {
            base.Damaged();

            int health = BattleManager.BattleData.health;
            switch (health)
            {
                case > 40:
                    CurrentState = 1;
                    break;
                case > 30:
                    CurrentState = 2;
                    break;
                case > 20:
                    CurrentState = 3;
                    break;
                case > 0:
                    CurrentState = 4;
                    break;
                default:
                    CurrentState = 4;
                    break;
            }

            BattleManager.Flash();
        }

        public void HeartAttack()
        {
            GameObject heart = Instantiate(HeartPrefab);
            heart.transform.position = new Vector2(CoreManager.SenseCore.PlayerPositionX, -2.54f);
        }

        public void SetCollider(Vector2 offset, Vector2 size)
        {
            Collider2D.offset = offset;
            Collider2D.size = size;
        }

        public void MoveX(float offsetX)
        {
            CoreManager.MoveCore.MoveX(offsetX);
        }
    }
}