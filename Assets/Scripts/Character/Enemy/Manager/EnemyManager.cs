using System;
using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Core;
using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM;
using Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ability_State;
using Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ground_State;
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
        }
    }
}