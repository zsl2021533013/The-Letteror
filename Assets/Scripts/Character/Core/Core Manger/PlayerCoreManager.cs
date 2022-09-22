using Character.Core.Core_Component;
using Character.Core.Core_Component.Move_Core;
using UnityEngine;

namespace Character.Core
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