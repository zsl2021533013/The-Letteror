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
        
        protected new BloodKingCoreManager CoreManager { get; private set; }
        
        public int CurrentState { get; private set; }
        
        #region FSM Component
        
        public BloodKingIdleState IdleState { get; private set; }
        public BloodKingChargeState ChargeState { get; private set; }
        public BloodKingAppearCloserState AppearCloserState { get; private set; }
        public BloodKingAppearFartherState AppearFartherState { get; private set; }
        public BloodKingDisappearCloserState DisappearCloserState { get; private set; }
        public BloodKingDisappearFartherState DisappearFartherState { get; private set; }
        public BloodKingBlueChargeState BlueChargeState { get; private set; }
        public BloodKingBlueChaseState BlueChaseState { get; private set; }
        public BloodKingTransformState TransformState { get; private set; }
        public BloodKingDeathState DeathState { get; private set; }

        #region Attack State

        public BloodKingAttack1State Attack1State { get; private set; }
        public BloodKingAttack2State Attack2State { get; private set; }
        public BloodKingAttack3_1State Attack3_1State { get; private set; }
        public BloodKingAttack3_2State Attack3_2State { get; private set; }
        public BloodKingAttack3_3State Attack3_3State { get; private set; }
        public BloodKingAttack3_4State Attack3_4State { get; private set; }
        public BloodKingAttack4_1State Attack4_1State { get; private set; }
        public BloodKingAttack4_2State Attack4_2State { get; private set; }
        public BloodKingAttack4_3State Attack4_3State { get; private set; }
        public BloodKingJumpAttackState JumpAttackState { get; private set; }
        public BloodKingBlueAttackState BlueAttackState { get; private set; }

        #endregion
        
        #endregion

        protected override void Awake()
        {
            base.Awake();

            CoreManager = (BloodKingCoreManager)base.CoreManager;
        }

        protected override void Start()
        {
            base.Start();

            CurrentState = 4;
            
            StateMachine.Initialize(IdleState);
            
        }

        protected override void InitializeFSM()
        {
            base.InitializeFSM();

            IdleState = new BloodKingIdleState(this, "idle");
            BlueChaseState = new BloodKingBlueChaseState(this, "move");
            AppearCloserState = new BloodKingAppearCloserState(this, "appear");
            AppearFartherState = new BloodKingAppearFartherState(this, "appear");
            DisappearCloserState = new BloodKingDisappearCloserState(this, "disappear");
            DisappearFartherState = new BloodKingDisappearFartherState(this, "disappear");
            BlueChargeState = new BloodKingBlueChargeState(this, "blueCharge");
            ChargeState = new BloodKingChargeState(this, "charge");
            TransformState = new BloodKingTransformState(this, "transform");
            DeathState = new BloodKingDeathState(this, "death");
            
            Attack1State = new BloodKingAttack1State(this, "attack1");
            Attack2State = new BloodKingAttack2State(this, "attack2");
            Attack3_1State = new BloodKingAttack3_1State(this, "attack3_1");
            Attack3_2State = new BloodKingAttack3_2State(this, "attack3_2");
            Attack3_3State = new BloodKingAttack3_3State(this, "attack3_3");
            Attack3_4State = new BloodKingAttack3_4State(this, "attack3_4");
            Attack4_1State = new BloodKingAttack4_1State(this, "attack4_1");
            Attack4_2State = new BloodKingAttack4_2State(this, "attack4_2");
            Attack4_3State = new BloodKingAttack4_3State(this, "attack4_3");
            BlueAttackState = new BloodKingBlueAttackState(this, "blueAttack");
            JumpAttackState = new BloodKingJumpAttackState(this, "jumpAttack");
        }

        public override void Damaged()
        {
            base.Damaged();

            /*int health = BattleManager.BattleData.health;
            switch (health)
            {
                case > 40:
                    CurrentState = 1;
                    break;
                case > 30:
                    CurrentState = 2;
                    break;
                case < 20:
                    CurrentState = 3;
                    break;
            }*/

            BattleManager.Flash();
        }

        public override void Death()
        {
            base.Death();
            
            StateMachine.TranslateToState(DeathState);
        }

        public void HeartAttack()
        {
            GameObject heart = Instantiate(HeartPrefab);
            heart.transform.position = new Vector2(CoreManager.SenseCore.PlayerPositionX, -2.54f);
        }
    }
}