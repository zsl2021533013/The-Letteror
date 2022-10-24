using Character.Base.Manager;
using Character.Enemy.Base.FSM.Enemy_State.Super_State;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ground_State
{
    public class EnemyChaseState : EnemyGroundState
    {
        private bool _inFlipRange;
        
        public EnemyChaseState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            if (inChaseRange && !inAttackRange)
            {
                coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * coreManager.MoveCore.CharacterDirection);
                return;
            }

            if (_inFlipRange)
            {
                coreManager.MoveCore.Flip();
            }
            
            if (!inChaseRange && !_inFlipRange)
            {
                stateMachine.TranslateToState(manager.IdleState);
                return;
            }
        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            _inFlipRange = coreManager.SenseCore.InFlipRange;
            inAttackRange = coreManager.SenseCore.InAttackRange;
        }
    }
}