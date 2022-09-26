using System;
using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Sub_State.Ability_State;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderManager : CharacterManager
    {
        #region FSM Attribute

        public HeartHolderIdleState IdleState { get; private set; } 

        #region Attack 1
        public HeartHoarderChaseState ChaseState { get; private set; } 
        public HeartHoarderAttack1StopStopState Attack1StopStopState { get; private set; }
        public HeartHoarderAttack1State Attack1State { get; private set; } 
        public HeartHoarderAttack1GetUpState Attack1GetUpState { get; private set; }
        #endregion
        
        #region Attack 2
        public HeartHoarderAttack2DisappearState Attack2DisappearState { get; private set; } 
        public HeartHoarderLowAppearState LowAppearState { get; private set; }    
        public HeartHoarderAttack2PrepareState Attack2PrepareState { get; private set; }
        public HeartHoarderAttack2State Attack2State { get; private set; } 
        public HeartHoarderAttack2StopState Attack2StopState { get; private set; } 
        #endregion

        #region Attack 3
        public HeartHoarderAttack3DisappearState Attack3DisappearState { get; private set; }
        public HeartHoarderHighAppearState HighAppearState { get; private set; }
        public HeartHoarderAttack3State Attack3State { get; private set; }
        public HeartHoarderAttack3GetUpState Attack3GetUpState { get; private set; }
        #endregion

        public HeartHoarderDeathState DeathState { get; private set; }
        
        #endregion

        protected override void Start()
        {
            base.Start();
            
            StateMachine.Initialize(IdleState);
        }

        protected override void InitializeFsm()
        {
            base.InitializeFsm();

            IdleState = new HeartHolderIdleState(this, "idle");

            #region Attack 1
            ChaseState = new HeartHoarderChaseState(this, "move");
            Attack1StopStopState = new HeartHoarderAttack1StopStopState(this, "attack1Stop");
            Attack1State = new HeartHoarderAttack1State(this, "attack1");
            Attack1GetUpState = new HeartHoarderAttack1GetUpState(this, "attack1GetUp");
            #endregion

            #region Attack 2
            Attack2DisappearState = new HeartHoarderAttack2DisappearState(this, "disappear");
            LowAppearState = new HeartHoarderLowAppearState(this, "lowAppear");
            Attack2PrepareState = new HeartHoarderAttack2PrepareState(this, "attack2Prepare");
            Attack2State = new HeartHoarderAttack2State(this, "attack2");
            Attack2StopState = new HeartHoarderAttack2StopState(this, "attack2Stop");
            #endregion

            #region Attack 3
            Attack3DisappearState = new HeartHoarderAttack3DisappearState(this, "disappear");
            HighAppearState = new HeartHoarderHighAppearState(this, "highAppear");
            Attack3State = new HeartHoarderAttack3State(this, "attack3");
            Attack3GetUpState = new HeartHoarderAttack3GetUpState(this, "attack3GetUp");
            #endregion

            DeathState = new HeartHoarderDeathState(this, "death");
        }

        public override void Damaged()
        {
            base.Damaged();
            
            IdleState.UpdateState(BattleManager.BattleData.health);
            BattleManager.Flash();
        }

        public override void Death()
        {
            base.Death();
            
            StateMachine.TranslateToState(DeathState);
        }
    }
}