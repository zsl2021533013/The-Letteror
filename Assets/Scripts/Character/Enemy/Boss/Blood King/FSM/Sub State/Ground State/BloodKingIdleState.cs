using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Base;
using UnityEditor;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State
{
    public class BloodKingIdleState : BloodKingState
    {
        private int _attackType;
        private bool _isPlayerUpwards;
        
        public BloodKingIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            if (coreManager.MoveCore.Direction != coreManager.SenseCore.PlayerDirection)
            {
                coreManager.MoveCore.Flip();
            }

            if (_isPlayerUpwards)
            {
                _attackType = Random.Range(0, 2);

                if (_attackType == 0)
                {
                    stateMachine.TranslateToState(manager.JumpAttackState);
                    return;
                }
            }
            
            _attackType = Random.Range(0, 4);
            
            switch (_attackType)
            {
                case 0 :
                    stateMachine.TranslateToState(manager.ChargeState);
                    break;
                case 1:
                    stateMachine.TranslateToState(manager.DisappearFartherState);
                    break;
                case 2:
                    stateMachine.TranslateToState(manager.DisappearCloserState);
                    break;
                case 3:
                    stateMachine.TranslateToState(manager.Attack3_1State);
                    break;
                default:
                    stateMachine.TranslateToState(manager.ChargeState);
                    break;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isPlayerUpwards = coreManager.SenseCore.DetectPlayerUpwards;
        }
    }
}