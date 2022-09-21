using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ground_State
{
    public class PlayerMoveState : PlayerGroundState
    {
        public PlayerMoveState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.SetVelocityX(((PlayerMoveCore)coreManager.MoveCore).PlayerData.movementVelocity * movementInput.x);
            ((PlayerManager)characterManager).Anim.SetFloat("velocityX", Mathf.Abs(coreManager.MoveCore.CurrentVelocity.x));
            
            if (!(coreManager.MoveCore as PlayerMoveCore))
            {
                Debug.LogError("Missing Player Move Core");
            }
            (coreManager.MoveCore as PlayerMoveCore).CheckFlip(((PlayerManager)characterManager).Input.MovementInput.x);
            
            if (Mathf.Abs(movementInput.x) <= 0.1f)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).IdleState);
            }
        }
    }
}