using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Air_Attack
{
    public class PlayerAirUpwardsAttackState : PlayerAttackState
    {
        private Vector2 movementInput;
        
        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.StateMachineData.airAttackCoolDown;
        
        public PlayerAirUpwardsAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            UpdateInput(manager.Input);
            
            coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.StateMachineData.airUpwardsAttackVelocityY);
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * movementInput.x);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * movementInput.x);
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            movementInput = input.MovementInput;
        }
    }
}