using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Base;
using UnityEditor;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State
{
    public class BloodKingIdleState : BloodKingState
    {
        private int _attackType;
        
        public BloodKingIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _attackType = Random.Range(0, 1);
            
            switch (_attackType)
            {
                case 0:
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
                    stateMachine.TranslateToState(manager.JumpAttackState);
                    break;
            }
        }
    }
}