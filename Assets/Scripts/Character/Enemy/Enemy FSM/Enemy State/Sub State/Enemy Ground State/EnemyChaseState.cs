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


        public EnemyChaseState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (inChaseRange && !inAttackRange)
            {
                coreManager.MoveCore.SetVelocityX(((EnemyMoveCore)coreManager.MoveCore).EnemyData.moveVelocity * coreManager.MoveCore.Direction);
                return;
            }

            if (_inFlipRange)
            {
                ((EnemyMoveCore)coreManager.MoveCore).Flip();
            }
            
            if (!inChaseRange && !_inFlipRange)
            {
                stateMachine.TranslateToState(((EnemyManager)characterManager).IdleState);
                return;
            }
        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            _inFlipRange = ((EnemySenseCore)coreManager.SenseCore).InFlipRange;
            inAttackRange = ((EnemySenseCore)coreManager.SenseCore).InAttackRange;
        }
    }
}