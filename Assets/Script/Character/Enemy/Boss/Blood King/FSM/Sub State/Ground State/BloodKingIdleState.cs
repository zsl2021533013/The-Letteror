using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Base;
using UnityEditor;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State
{
    public class BloodKingIdleState : BloodKingState
    {
        private int _currentState;
        private int _attackType;
        private int _formerAttackType;
        private bool _isPlayerUpwards;
        private bool _inAttackRange;

        public float offset;
        
        public BloodKingIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (isStateFinished)
            {
                return;
            }
            
            
            
            if (coreManager.MoveCore.CharacterDirection != coreManager.SenseCore.PlayerDirection)
            {
                coreManager.MoveCore.Flip();
            }
            
            ChooseAttackType();
        }

        private void ChooseAttackType()
        {
            _currentState = manager.CurrentState;
            
            if (_isPlayerUpwards)
            {
                _attackType = Random.Range(0, _currentState);

                if (_attackType > 0)
                {
                    stateMachine.TranslateToState(manager.JumpAttackState);
                    return;
                }
            }

            if (!_inAttackRange)
            {
                stateMachine.TranslateToState(manager.DisappearCloserState);
                return;
            }
            
            /*_attackType = Random.Range(0, _currentState);

            if (_attackType == _formerAttackType)
            {
                _attackType = (_attackType + 1) % _currentState;
            }
            _formerAttackType = _attackType;*/

            stateMachine.TranslateToState(manager.Attack4State);
            
            /*switch (_attackType)
            {
                case 0:
                    stateMachine.TranslateToState(manager.Attack1State);
                    break;
                case 1:
                    stateMachine.TranslateToState(manager.Attack4_1State);
                    break;
                case 2:
                    stateMachine.TranslateToState(manager.Attack3_1State);
                    break;
                case 3:
                    stateMachine.TranslateToState(manager.DisappearFartherState);
                    break;
            }*/
        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            _isPlayerUpwards = coreManager.SenseCore.DetectPlayerUpwards;
            _inAttackRange = coreManager.SenseCore.InAttackRange;
        }
    }
}