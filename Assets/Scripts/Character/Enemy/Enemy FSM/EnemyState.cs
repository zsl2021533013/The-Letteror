using Character.Core;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM
{
    public class EnemyState : MonoBehaviour
    {
        protected EnemyStateMachine stateMachine;
        protected EnemyManager enemyManager;
        protected CoreManager coreManager;    

        public float startTime { get; protected set; }

        protected string animBoolName;

        public EnemyState(EnemyManager enemyManager, EnemyStateMachine stateMachine, string animBoolName)
        {
            this.enemyManager = enemyManager;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
            coreManager = enemyManager.CoreManager;
        }

        public virtual void OnEnter()
        {
            startTime = Time.time;
            enemyManager.Anim.SetBool(animBoolName, true);
            DoChecks();
        }

        public virtual void OnExit()
        {
            enemyManager.Anim.SetBool(animBoolName, false);
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
