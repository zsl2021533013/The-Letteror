using Character.Base.Base_Manager;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ability_State
{
    public class PlayerDashState : PlayerAbilityState
    {
        private int _amountOfDashLeft;
        private Vector2 _startPosition;
        private Vector2 _currentPosition;


        public PlayerDashState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition = ((PlayerManager)characterManager).transform.position;
            DecreaseAmountOfDash();
            coreManager.MoveCore.SetVelocityX(((PlayerMoveCore)coreManager.MoveCore).PlayerData.dashVelocity * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public bool CheckAmountOfDash() => _amountOfDashLeft > 0;

        public void ResetAmountOfDash() => _amountOfDashLeft = ((PlayerMoveCore)coreManager.MoveCore).PlayerData.amountOfDash;

        public void DecreaseAmountOfDash() => --_amountOfDashLeft;
    }
}