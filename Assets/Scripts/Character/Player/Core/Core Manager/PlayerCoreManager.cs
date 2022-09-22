using Character.Base.Core.Core_Manger;
using Character.Player.Core.Core_Component;
using UnityEngine;

namespace Character.Player.Core.Core_Manager
{
    public class PlayerCoreManager : CoreManager
    {
        public new PlayerMoveCore MoveCore { get; private set; } 
        public new PlayerSenseCore SenseCore { get; private set; } 
        
        protected override void Awake()
        {
            base.Awake();

            if (!(base.MoveCore is PlayerMoveCore))
            {
                Debug.LogError("Missing Player Move Core");
            }
            if (!(base.SenseCore is PlayerSenseCore))
            {
                Debug.LogError("Missing Player Sense Core");
            }
            
            MoveCore = (PlayerMoveCore)base.MoveCore;
            SenseCore = (PlayerSenseCore)base.SenseCore;
            
        }
    }
}