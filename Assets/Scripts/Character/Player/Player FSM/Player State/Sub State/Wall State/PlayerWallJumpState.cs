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
        public PlayerWallJumpState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocity(((PlayerMoveCore)coreManager.MoveCore).PlayerData.wallJumpVelocity, ((PlayerMoveCore)coreManager.MoveCore).PlayerData.wallJumpAngle, -coreManager.MoveCore.Direction);
            if (!(coreManager.MoveCore as PlayerMoveCore))
            {
                Debug.LogError("Missing Player Move Core");
            }
            (coreManager.MoveCore as PlayerMoveCore).CheckFlip(((PlayerManager)characterManager).Input.MovementInput.x);
            ((PlayerManager)characterManager).JumpState.DecreaseAmountOfJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            ((PlayerManager)characterManager).Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
            ((PlayerManager)characterManager).Anim.SetFloat("velocityY", coreManager.MoveCore.CurrentVelocity.y);

            if (Time.time > startTime + ((PlayerMoveCore)coreManager.MoveCore).PlayerData.wallJumpTime)
            {
                isAbilityDone = true;
            }
        }
    }
}