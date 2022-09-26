using Character.Base.Core.Core_Manger;
using Character.Enemy.Boss.Heart_Hoarder.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderCoreManager : CoreManager
    {
        public new HeartHoarderMoveCore MoveCore { get; private set; } 
        
        protected override void Awake()
        {
            base.Awake();

            if (!(base.MoveCore is HeartHoarderMoveCore))
            {
                Debug.LogError("Missing Enemy Move Core");
            }

            MoveCore = (HeartHoarderMoveCore)base.MoveCore;
        }
    }
}