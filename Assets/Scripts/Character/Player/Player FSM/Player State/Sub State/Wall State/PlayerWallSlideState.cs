using Character.Base.Base_Manager;
using Character.Core.Core_Component.Move_Core;
using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;

namespace Character.Player.Player_State.Sub_State.Wall_State
{
    public class PlayerWallSlideState : PlayerWallState
    {
        public PlayerWallSlideState(CharacterManager characterManager, string animBoolName) : base(characterManager,
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
            
            coreManager.MoveCore.SetVelocityY(-((PlayerMoveCore)coreManager.MoveCore).PlayerData.wallSlideVelocity);
        }
    }
}