using Character.Base.Manager;
using Character.Enemy.FSM;

namespace Character.Enemy.Base.FSM.Enemy_State.Super_State
{
    public class EnemyGroundState : EnemyState
    {
        protected bool inChaseRange;
        protected bool inAttackRange;
        protected bool inSpecialAttackRange;

        public EnemyGroundState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (inAttackRange && manager.AttackState.AttackEnable)
            {
                stateMachine.TranslateToState(manager.AttackState);
                return;
            }

            if (inSpecialAttackRange && manager.SpecialAttackState.AttackEnable)
            {
                stateMachine.TranslateToState(manager.SpecialAttackState);
                return;
            }
            
            if (inChaseRange && !inAttackRange)
            {
                stateMachine.TranslateToState(manager.ChaseState);
                return;
            }
            
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            inChaseRange = coreManager.SenseCore.InChaseRange;
            inAttackRange = coreManager.SenseCore.InAttackRange;
            inSpecialAttackRange = coreManager.SenseCore.InSpecialAttackRange;
        }
    }
}