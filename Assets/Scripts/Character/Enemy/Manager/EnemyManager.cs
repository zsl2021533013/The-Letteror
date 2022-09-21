using System;
using Character.Core;
using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM;
using Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ability_State;
using Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ground_State;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Enemy.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData;

        #region FSM Attribute
        
        public EnemyStateMachine StateMachine { get; private set; }
        public EnemyIdleState IdleState { get; private set; }
        public EnemyChaseState ChaseState { get; private set; }
        public EnemyAttackState AttackState { get; private set; }
        public EnemyPatrolState PatrolState { get; private set; }

        #endregion

        #region Component
        
        public EnemyCoreManager CoreManager { get; private set; }
        public Animator Anim { get; private set; }

        #endregion

        private void Awake()
        {
            InitializeFsm();
            Anim = GetComponentInChildren<Animator>();
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
            CoreManager = GetComponentInChildren<EnemyCoreManager>(); // CoreManager 要在最开始获取
            
            StateMachine = new EnemyStateMachine();
            IdleState = new EnemyIdleState(this, enemyData, "idle");
            ChaseState = new EnemyChaseState(this, enemyData, "move");
            AttackState = new EnemyAttackState(this, enemyData, "attack");
            PatrolState = new EnemyPatrolState(this, enemyData, "move");
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, Vector3.right * enemyData.patrolRange);
            Gizmos.DrawRay(transform.position, Vector3.left * enemyData.patrolRange);
        }
    }
}