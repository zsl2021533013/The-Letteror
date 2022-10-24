using Character.Base.Manager;
using Character.Player.Manager;

namespace Script.Character.Player.Manager
{
    public class PlayerAnimationManager : CharacterAnimationManager
    {
        protected new PlayerManager manager;

        protected override void Awake()
        {
            base.Awake();

            manager = (PlayerManager)base.manager;
        }

        public void ResetAttackInput() => manager.Input.ResetAttackInput();
    }
}
