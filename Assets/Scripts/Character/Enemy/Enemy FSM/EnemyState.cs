using Character.Core;
using Character.Enemy.Data;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM
{
    public class EnemyState
    {
        protected EnemyStateMachine stateMachine;
        protected EnemyCoreManager coreManager;    
        protected EnemyManager enemyManager;
        protected EnemyData enemyData;

        public float startTime { get; protected set; }

        protected string _animBoolName;

        public EnemyState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName)
        {
            this.enemyManager = enemyManager;
            this._animBoolName = animBoolName;
            this.enemyData = enemyData;
            stateMachine = enemyManager.StateMachine;
            coreManager = enemyManager.CoreManager;
        }

        public virtual void OnEnter()
        {
            startTime = Time.time;
            enemyManager.Anim.SetBool(_animBoolName, true);
            DoChecks();
            Debug.Log("Enter " + _animBoolName + " State");
        }

        public virtual void OnExit()
        {
            enemyManager.Anim.SetBool(_animBoolName, false);
            //Debug.Log("Exit " + _animBoolName + " State");
        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }
    }
}
