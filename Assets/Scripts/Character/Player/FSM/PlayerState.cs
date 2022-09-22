using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using Character.Player.Core.Core_Manager;
using Character.Player.Manager;

namespace Character.Player.FSM
{
    public class PlayerState : CharacterState
    {
        protected new PlayerManager manager;
        protected new PlayerCoreManager coreManager;
        
        public PlayerState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
            this.manager = (PlayerManager)manager;
            coreManager = (PlayerCoreManager)manager.CoreManager;
        }
    }
}
