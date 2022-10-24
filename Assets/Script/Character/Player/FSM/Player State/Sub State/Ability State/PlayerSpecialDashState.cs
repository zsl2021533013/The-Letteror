using Character.Base.Manager;
using Script.Character.Player.FSM.Player_State.Super_State;
using Script.Character.Player.Input_System;
using Script.Environment;
using UnityEngine;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerSpecialDashState : PlayerAbilityState
    {
        private Vector2 _movementInput;
        private bool _specialDashInput;

        private DashFruitController _dashFruit;
        
        public PlayerSpecialDashState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            manager.ResetAbility();
            manager.JumpState.DecreaseAmountOfJumps();
            
            Time.timeScale = 0f;
            startTime = Time.unscaledTime;

            coreManager.MoveCore.OpenArrow();
            _dashFruit = coreManager.SenseCore.GetDashFruit();

            if (_dashFruit)
            {
                _dashFruit.PlayerEnter();
            }
            else
            {
                Time.timeScale = 1f;
                isAbilityDone = true;
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.SetArrowRotation(_movementInput);

            if (!_specialDashInput || Time.unscaledTime > startTime + coreManager.MoveCore.StateMachineData.pauseTime)
            {
                Time.timeScale = 1f;
                coreManager.MoveCore.SetVelocity(coreManager.MoveCore.StateMachineData.specialDashVelocity,
                    _movementInput, 1);
                manager.AirState.EndJumping();
                isAbilityDone = true;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            
            coreManager.MoveCore.CloseArrow();

            if (_dashFruit)
            {
                _dashFruit.PlayerExit();
            }
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            base.UpdateInput(input);

            _movementInput = input.MovementInput;
            _specialDashInput = input.SpecialDashInput;
        }
    }
}