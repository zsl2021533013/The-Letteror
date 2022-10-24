using Character.Base.Manager;
using Script.Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Air_Attack
{
    public class PlayerAirHorizontalAttack1State : PlayerAttackState
    {
        private bool _attackInput;
        
        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.StateMachineData.airAttackCoolDown;
        
        public PlayerAirHorizontalAttack1State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.StateMachineData.airAttack1VelocityX *
                                              coreManager.MoveCore.CharacterDirection);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeY(startPosition);
        }
        
        protected override void OnAnimationFinish()
        {
            if (_attackInput)
            { 
                stateMachine.TranslateToState(manager.AirHorizontalAttack2State); 
                manager.Input.ResetAttackInput();
            }
            else
            {
                isAbilityDone = true;
            }
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            _attackInput = input.AttackInput;
        }
    }
}