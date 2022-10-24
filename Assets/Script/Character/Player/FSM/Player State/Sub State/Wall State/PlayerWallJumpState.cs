using Character.Base.Manager;
using Script.Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Wall_State
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

            coreManager.MoveCore.SetVelocity(coreManager.MoveCore.StateMachineData.wallJumpVelocity,
                coreManager.MoveCore.StateMachineData.wallJumpAngle, -coreManager.MoveCore.CharacterDirection);

            coreManager.MoveCore.CheckFlip(manager.Input);
            manager.JumpState.DecreaseAmountOfJumps();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
           manager.AnimationManager.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
           manager.AnimationManager.SetFloat("velocityY", coreManager.MoveCore.CurrentVelocity.y);

            if (Time.time > startTime + coreManager.MoveCore.StateMachineData.wallJumpTime)
            {
                isAbilityDone = true;
            }
        }
    }
}