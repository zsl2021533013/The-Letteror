using System;
using Character.Core;
using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM;
using Character.Enemy.Enemy_State;
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
        }
    }
}