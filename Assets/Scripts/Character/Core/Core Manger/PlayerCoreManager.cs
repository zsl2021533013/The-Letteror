using Character.Core.Core_Component;
using Character.Core.Core_Component.Move_Core;
using UnityEngine;

namespace Character.Core
{
    public class PlayerCoreManager : CoreManager
    {
        protected override void Awake()
        {
            base.Awake();

            if (!(MoveCore is PlayerMoveCore))
            {
                Debug.LogError("Missing Player Move Core");
            }
            if (!(SenseCore is PlayerSenseCore))
            {
                Debug.LogError("Missing Player Sense Core");
            }
        }
    }
}