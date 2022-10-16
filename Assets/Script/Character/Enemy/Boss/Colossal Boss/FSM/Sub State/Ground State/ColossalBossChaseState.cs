using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Base_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ground_State
{
    public class ColossalBossChaseState : ColossalBossState
    {
        private int _currentState;
        private int _attackType;
        private int _formerAttackType;
        
        public ColossalBossChaseState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _currentState = manager.CurrentState;
            
            switch (coreManager.MoveCore.CharacterDirection)
            {
                case 1 when coreManager.SenseCore.PlayerDirection == -1:
                    manager.TurnLeftState.SetFormerState(this);
                    stateMachine.TranslateToState(manager.TurnLeftState);
                    return;
                case -1 when coreManager.SenseCore.PlayerDirection == 1:
                    manager.TurnRightState.SetFormerState(this);
                    stateMachine.TranslateToState(manager.TurnRightState);
                    return;
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

            switch (coreManager.MoveCore.CharacterDirection)
            {
                case 1 when coreManager.SenseCore.PlayerDirection == -1:
                    manager.TurnLeftState.SetFormerState(this);
                    stateMachine.TranslateToState(manager.TurnLeftState);
                    return;
                case -1 when coreManager.SenseCore.PlayerDirection == 1:
                    manager.TurnRightState.SetFormerState(this);
                    stateMachine.TranslateToState(manager.TurnRightState);
                    return;
            }
            
            if (coreManager.SenseCore.InAttackRange)
            {
                _attackType = Random.Range(0, _currentState);
                if (_attackType == _formerAttackType)
                {
                    _attackType = (_attackType + 1) % _currentState;
                }
                _formerAttackType = _attackType;
                
                switch (_attackType)
                {
                    case 0:
                        stateMachine.TranslateToState(manager.Attack1State);
                        return;
                    case 1:
                        stateMachine.TranslateToState(manager.Attack3State);
                        return;
                    case 2:
                        stateMachine.TranslateToState(manager.Attack4State);
                        return;
                }
            }
        }
    }
}