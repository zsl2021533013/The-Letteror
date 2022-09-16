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
        
        public PlayerDashState(PlayerManager playerManager, PlayerStateMachine stateMachine,
            PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition = playerManager.transform.position;
            DecreaseAmountOfDash();
            playerManager.SetVelocityY(0f);
            playerManager.SetVelocityX(playerData.dashVelocity * playerManager.PlayerDirection);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            HoldPositionY();
            
            playerManager.SetVelocityY(0f);
            
            if (isAnimationFinished)
            {
                isAbilityDone = true;
            }
        }

        public bool CheckAmountOfDash() => _amountOfDashLeft > 0;

        public void ResetAmountOfDash() => _amountOfDashLeft = playerData.amountOfDash;

        public void DecreaseAmountOfDash() => --_amountOfDashLeft;

        private void HoldPositionY()
        {
            _currentPosition = playerManager.transform.position;
            _currentPosition.y = _startPosition.y;
            playerManager.transform.position = _currentPosition;
        }
    }
}