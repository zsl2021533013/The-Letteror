using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerDashState : PlayerAbilityState
    {
        private int _amountOfDashLeft;
        private Vector2 _startPosition;
        private Vector2 _currentPosition;


        public PlayerDashState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition =manager.transform.position;
            DecreaseAmountOfDash();
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.dashVelocity * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public bool CheckAmountOfDash() => _amountOfDashLeft > 0;

        public void ResetAmountOfDash() => _amountOfDashLeft = coreManager.MoveCore.PlayerData.amountOfDash;

        public void DecreaseAmountOfDash() => --_amountOfDashLeft;
    }
}