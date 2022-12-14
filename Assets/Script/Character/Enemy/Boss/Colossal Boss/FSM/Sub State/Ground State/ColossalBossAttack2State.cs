using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Base_State;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ground_State
{
    public class ColossalBossAttack2State : ColossalBossState
    {
        public ColossalBossAttack2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            switch (coreManager.MoveCore.CharacterDirection)
            {
                case 1 when coreManager.MoveCore.Attack2Direction == -1:
                    manager.TurnLeftState.SetFormerState(this);
                    stateMachine.TranslateToState(manager.TurnLeftState);
                    break;
                case -1 when coreManager.MoveCore.Attack2Direction == 1:
                    manager.TurnRightState.SetFormerState(this);
                    stateMachine.TranslateToState(manager.TurnRightState);
                    break;
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * coreManager.MoveCore.CharacterDirection);

            if (coreManager.SenseCore.InTargetPoint)
            {
                stateMachine.TranslateToState(manager.Attack2StopState);
                return;
            }
        }
    }
}