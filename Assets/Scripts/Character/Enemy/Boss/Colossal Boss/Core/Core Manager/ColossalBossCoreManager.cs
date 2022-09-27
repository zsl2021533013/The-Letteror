using Character.Base.Core.Core_Manger;
using Character.Enemy.Boss.Colossal_Boss.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.Core.Core_Manager
{
    public class ColossalBossCoreManager : CoreManager
    {
        public new ColossalBossMoveCore MoveCore { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();

            if (!(base.MoveCore is ColossalBossMoveCore))
            {
                Debug.LogError("Missing Enemy Move Core");
            }

            MoveCore = (ColossalBossMoveCore)base.MoveCore;
        }
    }
}