using Character.Core.Core_Component;
using UnityEngine;

namespace Character.Core
{
    public class EnemyCoreManager : CoreManager
    {
        public new EnemyMoveCore MoveCore { get; private set; } 
        public new EnemySenseCore SenseCore { get; private set; } 
        
        protected override void Awake()
        {
            base.Awake();

            if (!(base.MoveCore is EnemyMoveCore))
            {
                Debug.LogError("Missing Enemy Move Core");
            }
            if (!(base.SenseCore is EnemySenseCore))
            {
                Debug.LogError("Missing Enemy Sense Core");
            }
            
            MoveCore = (EnemyMoveCore)base.MoveCore;
            SenseCore = (EnemySenseCore)base.SenseCore;
        }
    }
}