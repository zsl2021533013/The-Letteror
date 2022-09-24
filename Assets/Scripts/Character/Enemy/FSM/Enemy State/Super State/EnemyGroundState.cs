using Character.Base.Manager;

namespace Character.Enemy.FSM.Enemy_State.Super_State
{
    public class EnemyGroundState : EnemyState
    {
        protected bool inChaseRange;
        protected bool inAttackRange;


        public EnemyGroundState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (inChaseRange && !inAttackRange)
            {
                stateMachine.TranslateToState(manager.ChaseState);
                return;
            }
            
            if (inAttackRange && manager.AttackState.AttackEnable)
            {
                stateMachine.TranslateToState(manager.AttackState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            inChaseRange = coreManager.SenseCore.InChaseRange;
            inAttackRange = coreManager.SenseCore.InAttackRange;
        }
    }
}