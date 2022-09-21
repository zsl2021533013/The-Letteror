using Character.Base.Base_Manager;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.Player_State.Sub_State.Ground_State
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (isStateFinished)
            {
                return;
            }
            
            if (movementInput.x != 0f)
            {
                stateMachine.TranslateToState(((PlayerManager)characterManager).MoveState);
            }
        }
    }
}