using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;
using Character.Player.Player_State.Super_State;

namespace Character.Player.Player_State.Sub_State.Wall_State
{
    public class PlayerWallSlideState : PlayerWallState
    {
        public PlayerWallSlideState(PlayerManager playerManager,
            PlayerData playerData, string animBoolName) : base(playerManager, playerData, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.SetVelocityY(-playerData.wallSlideVelocity);
        }
    }
}