using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Base;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State
{
    public class BloodKingBlueIdleState : BloodKingState
    {
        private bool _inAttack1Range;
        
        public BloodKingBlueIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }

            if (manager.CurrentState > 1)
            {
                Debug.Log(manager.CurrentState);
                stateMachine.TranslateToState(manager.Transform2State);
                return;
            }
            
            if (_inAttack1Range)
            {
                stateMachine.TranslateToState(manager.BlueAttackState);
                return;
            }
            else
            {
                stateMachine.TranslateToState(manager.BlueChaseState);
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _inAttack1Range = coreManager.SenseCore.InAttack1Range;
        }
    }
}