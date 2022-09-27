using Character.Base.Manager;
using Character.Enemy.FSM;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHolderIdleState : HeartHoarderState
    {
        private int _currentState; //Boss目前状态
        private int _attackType;
        private int _formerAttackType;
        
        public HeartHolderIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
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
                    stateMachine.TranslateToState(manager.Attack2DisappearState);
                    break;
                case 2:
                    stateMachine.TranslateToState(manager.Attack3DisappearState);
                    break;
                default:
                    stateMachine.TranslateToState(manager.Attack3DisappearState);
                    break;
            }
        }

        public void SetState(int currentState) => _currentState = currentState;
    }
}
