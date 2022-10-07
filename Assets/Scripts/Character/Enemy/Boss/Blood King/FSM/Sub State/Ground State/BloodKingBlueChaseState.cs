using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Base;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State
{
    public class BloodKingBlueChaseState : BloodKingState
    {
        public BloodKingBlueChaseState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (coreManager.MoveCore.CharacterDirection != coreManager.SenseCore.PlayerDirection)
            {
                coreManager.MoveCore.Flip();
            }
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * coreManager.MoveCore.CharacterDirection);
            
            if (coreManager.SenseCore.InAttack1Range)
            {
                stateMachine.TranslateToState(manager.BlueAttackState);
                return;
            }
        }
    }
}