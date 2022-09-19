﻿using Character.Player.Data;
using Character.Player.Input_System;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Character.Player.Player_State.Sub_State.Ability_State
{
    public class PlayerAttack1State : PlayerAbilityState
    {
        private Vector2 _startPosition;
        private bool _attackInput;
        
        public PlayerAttack1State(PlayerManager playerManager, PlayerData playerData,
            string animBoolName) : base(playerManager, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition = playerManager.transform.position;
            coreManager.MoveCore.SetVelocityX(playerData.attackVelocity1 * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }

            UpdateInput(playerManager.Input);

            coreManager.MoveCore.FreezeY(_startPosition);
        }

        protected override void OnAnimationFinish()
        {
            if (_attackInput)
            {
                stateMachine.TranslateToState(playerManager.Attack2State);
                playerManager.Input.ResetAttackInput();
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