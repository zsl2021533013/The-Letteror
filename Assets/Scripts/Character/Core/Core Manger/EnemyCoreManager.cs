using Character.Core.Core_Component;
using UnityEngine;

namespace Character.Core
{
    public class EnemyCoreManager : CoreManager
    {
        protected override void Awake()
        {
            base.Awake();

            if (!(MoveCore is EnemyMoveCore))
            {
                Debug.LogError("Missing Enemy Move Core");
            }
            if (!(SenseCore is EnemySenseCore))
            {
                Debug.LogError("Missing Enemy Sense Core");
            }
        }
    }
}