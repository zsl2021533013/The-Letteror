using Character.Base.Manager;
using Script.Character.Player.Input_System;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Ground_Attack
{
    public class PlayerGroundAttack1State : PlayerAttackState
    {
        private bool _attackInput;
        
        public PlayerGroundAttack1State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.StateMachineData.groundAttack1VelocityX * coreManager.MoveCore.CharacterDirection);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.FreezeY(startPosition);
        }

        protected override void OnAnimationFinish()
        {
            if (_attackInput)
            { 
                stateMachine.TranslateToState(manager.GroundAttack2State); 
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