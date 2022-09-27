using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Base_State;
using Character.Enemy.Boss.Colossal_Boss.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ground_State
{
    public class ColossalBossIdleState : ColossalBossState
    {
        private int _currentState;
        private int _attackType;
        private int _formerAttackType;

        public int CurrentState => _currentState;
        
        public ColossalBossIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
            _currentState = 1;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _attackType = Random.Range(0, _currentState);
            if (_attackType == _formerAttackType)
            {
                _attackType = (_attackType + 1) % _currentState;
            }
            _formerAttackType = _attackType;
            
            switch (_attackType)
            {
                case 0:
                    stateMachine.TranslateToState(manager.ChaseState);
                    break;
                case 1:
                    stateMachine.TranslateToState(manager.BuffState);
                    break;
                case 2:
                    stateMachine.TranslateToState(manager.Attack2State);
                    break;
            }
        }
        
        public void SetState(int currentState) => _currentState = currentState;
    }
}