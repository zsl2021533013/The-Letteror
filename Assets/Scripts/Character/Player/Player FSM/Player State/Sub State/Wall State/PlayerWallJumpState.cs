using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Wall_State
{
    public class PlayerWallJumpState : PlayerAbilityState
    {
        public PlayerWallJumpState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocity(coreManager.MoveCore.PlayerData.wallJumpVelocity, coreManager.MoveCore.PlayerData.wallJumpAngle, -coreManager.MoveCore.Direction);

            coreManager.MoveCore.CheckFlip(manager.Input.MovementInput.x);
            manager.JumpState.DecreaseAmountOfJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
           manager.Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
           manager.Anim.SetFloat("velocityY", coreManager.MoveCore.CurrentVelocity.y);

            if (Time.time > startTime + coreManager.MoveCore.PlayerData.wallJumpTime)
            {
                isAbilityDone = true;
            }
        }
    }
}