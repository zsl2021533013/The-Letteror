using Character.Base.Base_Manager;
using Character.Base.FSM_Base.Base_State;
using Character.Core;
using Character.Player.Data;
using Character.Player.Manager;
using UnityEngine;

namespace Character.Player.Player_FSM
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
