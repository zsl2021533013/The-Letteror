using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ability_State
{
    public class PlayerAttack3State : PlayerAbilityState
    {
        private Vector2 _startPosition;

        public PlayerAttack3State(PlayerManager playerManager, PlayerData playerData,
            string animBoolName) : base(playerManager, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition = playerManager.transform.position;
            coreManager.MoveCore.SetVelocityX(playerData.attackVelocity3 * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.FreezeY(_startPosition);
        }
    }
}