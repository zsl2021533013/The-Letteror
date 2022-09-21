using Character.Core;
using Character.Enemy.Data;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM
{
    public class EnemyState
    {
        public bool IsStateFinished { get; private set; }
        
        protected EnemyStateMachine stateMachine;
        protected CoreManager coreManager;    
        protected EnemyManager enemyManager;
        protected EnemyData enemyData;
        protected float startTime;
        protected bool isAnimationFinish;

        private string _animBoolName;
        
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
            isAnimationFinish = false;
            IsStateFinished = false;
            //Debug.Log("Enter " + _animBoolName + " State");
        }

        public virtual void OnExit()
        {
            enemyManager.Anim.SetBool(_animBoolName, false);
            IsStateFinished = true;
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
        
        public void AnimationFinish() => isAnimationFinish = true;
    }
}
