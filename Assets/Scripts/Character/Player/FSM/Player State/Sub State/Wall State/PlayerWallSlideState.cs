using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;

namespace Character.Player.FSM.Player_State.Sub_State.Wall_State
{
    public class PlayerWallSlideState : PlayerWallState
    {
        public PlayerWallSlideState(CharacterManager manager, string animBoolName) : base(manager,
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
            
            coreManager.MoveCore.SetVelocityY(-coreManager.MoveCore.PlayerData.wallSlideVelocity);
        }
    }
}