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

        private float _offset;
        
        public BloodKingIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            if (_offset > 0f)
            {
                coreManager.MoveCore.MoveX(_offset * coreManager.MoveCore.CharacterDirection);
                _offset = -1f;
            }
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
            
            _attackType = Random.Range(0, 2);

            if (_attackType == _formerAttackType)
            {
                _attackType = (_attackType + 1) % 2;
            }
            _formerAttackType = _attackType;

            switch (_attackType)
            {
                case 0:
                    stateMachine.TranslateToState(manager.Attack3State);
                    break;
                case 1:
                    stateMachine.TranslateToState(manager.Attack4State);
                    break;
                /*case 2:
                    stateMachine.TranslateToState(manager.Attack3State);
                    break;
                case 3:
                    stateMachine.TranslateToState(manager.DisappearFartherState);
                    break;*/
            }
        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            _isPlayerUpwards = coreManager.SenseCore.DetectPlayerUpwards;
            _inAttackRange = coreManager.SenseCore.InAttackRange;
        }

        public void SetOffset(float offset) => _offset = offset;
    }
}