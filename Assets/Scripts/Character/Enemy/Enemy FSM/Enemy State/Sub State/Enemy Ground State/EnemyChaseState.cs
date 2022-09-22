using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM.Enemy_State.Super_State;
using Character.Enemy.Manager;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ground_State
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

            if (inChaseRange && !inAttackRange)
            {
                coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.EnemyData.moveVelocity * coreManager.MoveCore.Direction);
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