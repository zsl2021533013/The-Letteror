using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDownwardsAttack2State : PlayerAttackState
    {
        private bool _isGrounded;
        
        public PlayerSpecialDownwardsAttack2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            coreManager.MoveCore.SetVelocityY(-coreManager.MoveCore.StateMachineData.specialDownwardsAttackVelocityY);
            coreManager.MoveCore.FreezeX(startPosition);
            
            if (_isGrounded)
            {
                stateMachine.TranslateToState(manager.SpecialDownwardsAttack3State);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isGrounded = coreManager.SenseCore.DetectGround;
        }
    }
}