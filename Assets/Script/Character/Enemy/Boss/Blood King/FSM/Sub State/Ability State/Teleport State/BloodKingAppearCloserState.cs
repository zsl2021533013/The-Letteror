using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Teleport_State
{
    public class BloodKingAppearCloserState : BloodKingAbilityState
    {
        private int _currentState;
        private int _appearType;
        private int _attackType;
        private int _formerAttackType;

        public BloodKingAppearCloserState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _appearType = Random.Range(0, 2);

            switch (_appearType)
            {
                case 0:
                    if ((coreManager.SenseCore.PlayerPositionX - coreManager.SenseCore.attack1Range) <
                        coreManager.MoveCore.leftPointX)
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX +
                                                    coreManager.SenseCore.attack1Range);
                    }
                    else
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX -
                                                    coreManager.SenseCore.attack1Range);
                    }
                    break;
                case 1:
                    if ((coreManager.SenseCore.PlayerPositionX + coreManager.SenseCore.attack1Range) >
                        coreManager.MoveCore.rightPointX)
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX -
                                                    coreManager.SenseCore.attack1Range);
                    }
                    else
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX +
                                                    coreManager.SenseCore.attack1Range);
                    }
                    break;
            }
            
            if (coreManager.MoveCore.CharacterDirection != coreManager.SenseCore.PlayerDirection)
            {
                coreManager.MoveCore.Flip();
            }
        }

        protected override void OnAnimationFinish()
        {
            _currentState = manager.CurrentState;
            
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
                    break;
                case 2:
                    stateMachine.TranslateToState(manager.Attack4State);
                    break;
                case 3:
                    stateMachine.TranslateToState(manager.Attack3State);
                    break;
                default:
                    stateMachine.TranslateToState(manager.Attack1State);
                    break;
            }
        }
    }
}