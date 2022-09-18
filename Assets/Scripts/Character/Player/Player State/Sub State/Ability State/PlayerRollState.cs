using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ability_State
{
    public class PlayerRollState : PlayerAbilityState
    {
        public PlayerRollState(PlayerManager playerManager,
            PlayerData playerData, string animBoolName) : base(playerManager, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityY(0f);
            coreManager.MoveCore.SetVelocityX(playerData.rollVelocity * coreManager.MoveCore.Direction);
        }
    }
}