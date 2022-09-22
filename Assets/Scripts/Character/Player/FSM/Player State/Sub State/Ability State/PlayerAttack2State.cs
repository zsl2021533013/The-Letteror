using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using Character.Player.Input_System;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerAttack2State : PlayerAbilityState
    {
        private Vector2 _startPosition;
        private bool _attackInput;

        public PlayerAttack2State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition =manager.transform.position;
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.attackVelocity2 * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }

            UpdateInput(manager.Input);

            coreManager.MoveCore.FreezeY(_startPosition);
        }

        protected override void OnAnimationFinish()
        {
            if (_attackInput)
            {
                stateMachine.TranslateToState(manager.Attack3State);
               manager.Input.ResetAttackInput();
            }
            else
            {
                isAbilityDone = true;
            }
        }

        private void UpdateInput(PlayerInputHandler input)
        {
            _attackInput = input.AttackInput;
        }
    }
}