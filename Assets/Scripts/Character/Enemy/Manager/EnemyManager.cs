﻿using System;
using Character.Base.Manager;
using Character.Enemy.Core.Core_Manager;
using Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State;
using Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ground_State;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Enemy.Manager
{
    public class EnemyManager : CharacterManager
    {
        public new EnemyCoreManager CoreManager { get; private set; }
        
        #region FSM Attribute
        
        public EnemyIdleState IdleState { get; private set; }
        public EnemyChaseState ChaseState { get; private set; }
        public EnemyAttackState AttackState { get; private set; }
        public EnemyPatrolState PatrolState { get; private set; }
        public EnemyGetHitState GetHitState { get; private set; }
        public EnemyDieState DieState { get; private set; }

        #endregion

        protected override void Awake()
        {
            base.Awake();

            CoreManager = (EnemyCoreManager)base.CoreManager;
        }

        protected override void Start()
        {
            StateMachine.Initialize(IdleState);
        }
        
        protected override void InitializeFsm()
        {
            base.InitializeFsm();
            
            IdleState = new EnemyIdleState(this, "idle");
            ChaseState = new EnemyChaseState(this, "move");
            AttackState = new EnemyAttackState(this, "attack");
            PatrolState = new EnemyPatrolState(this, "move");
            GetHitState = new EnemyGetHitState(this, "getHit");
            DieState = new EnemyDieState(this, "die");
        }

        public override void GetHit()
        {
            base.GetHit();

            if (CoreManager.SenseCore.InFlipRange)
            {
                CoreManager.MoveCore.Flip();
            }
            
            StateMachine.TranslateToState(GetHitState);
        }

        public override void Die()
        {
            base.Die();
            
            if (CoreManager.SenseCore.InFlipRange)
            {
                CoreManager.MoveCore.Flip();
            }
            
            StateMachine.TranslateToState(DieState);
        }
    }
}