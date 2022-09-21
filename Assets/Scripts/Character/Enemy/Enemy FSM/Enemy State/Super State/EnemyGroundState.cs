using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Enemy.Data;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Super_State
{
    public class EnemyGroundState : EnemyState
    {
        protected bool inChaseRange;
        protected bool inAttackRange;


        public EnemyGroundState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (inChaseRange && !inAttackRange)
            {
                stateMachine.TranslateToState(((EnemyManager)characterManager).ChaseState);
                return;
            }
            
            if (inAttackRange && ((EnemyManager)characterManager).AttackState.AttackEnable)
            {
                stateMachine.TranslateToState(((EnemyManager)characterManager).AttackState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            inChaseRange = ((EnemySenseCore)coreManager.SenseCore).InChaseRange;
            inAttackRange = ((EnemySenseCore)coreManager.SenseCore).InAttackRange;
        }
    }
}