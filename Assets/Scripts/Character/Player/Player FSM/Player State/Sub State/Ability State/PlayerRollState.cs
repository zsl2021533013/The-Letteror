using Character.Base.Base_Manager;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ability_State
{
    public class PlayerRollState : PlayerAbilityState
    {
        public PlayerRollState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityY(0f);
            coreManager.MoveCore.SetVelocityX(((PlayerMoveCore)coreManager.MoveCore).PlayerData.rollVelocity * coreManager.MoveCore.Direction);
        }
    }
}